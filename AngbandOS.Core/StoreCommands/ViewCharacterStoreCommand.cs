using Cthangband.Commands;
using Cthangband.Enumerations;
using Cthangband.UI;
using System;

namespace Cthangband.StoreCommands
{
    /// <summary>
    /// View the character sheet
    /// </summary>
    [Serializable]
    internal class ViewCharacterStoreCommand : IStoreCommand
    {
        public char Key => 'C';

        public bool IsEnabled(Store store) => true;

        public string Description => "";

        public bool RequiresRerendering => true;

        public void Execute(SaveGame saveGame, Store store)
        {
            DoCmdViewCharacter(saveGame);
        }

        public static void DoCmdViewCharacter(SaveGame saveGame)
        {
            // Save the current screen
            saveGame.Gui.FullScreenOverlay = true;
            saveGame.Gui.Save();
            saveGame.Gui.SetBackground(BackgroundImage.Paper);
            // Load the character viewer
            CharacterViewer characterViewer = new CharacterViewer(saveGame, saveGame.Player);
            while (true)
            {
                characterViewer.DisplayPlayer();
                saveGame.Gui.Print(Colour.Orange, "[Press 'c' to change name, or ESC]", 43, 23);
                char keyPress = saveGame.Gui.Inkey();
                // Escape breaks us out of the loop
                if (keyPress == '\x1b')
                {
                    break;
                }
                // 'c' changes name
                if (keyPress == 'c' || keyPress == 'C')
                {
                    saveGame.Player.InputPlayerName();
                }
                saveGame.MsgPrint(null);
            }
            // Restore the screen
            saveGame.Gui.SetBackground(BackgroundImage.Overhead);
            saveGame.Gui.Load();
            saveGame.Gui.FullScreenOverlay = false;
            saveGame.Player.RedrawNeeded.Set(RedrawFlag.PrWipe | RedrawFlag.PrBasic | RedrawFlag.PrExtra | RedrawFlag.PrMap |
                             RedrawFlag.PrEquippy);
            saveGame.HandleStuff();
        }
    }
}
