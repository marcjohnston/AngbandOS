namespace AngbandOS.StoreCommands
{
    /// <summary>
    /// View the character sheet
    /// </summary>
    [Serializable]
    internal class ViewCharacterStoreCommand : BaseStoreCommand
    {
        public override char Key => 'C';

        public override string Description => "";

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            DoCmdViewCharacter(storeCommandEvent.SaveGame);
            storeCommandEvent.RequiresRerendering = true;
        }

        public static void DoCmdViewCharacter(SaveGame saveGame)
        {
            // Save the current screen
            saveGame.FullScreenOverlay = true;
            saveGame.SaveScreen();
            saveGame.SetBackground(BackgroundImage.Paper);
            // Load the character viewer
            CharacterViewer characterViewer = new CharacterViewer(saveGame);
            while (true && !saveGame.Shutdown)
            {
                characterViewer.DisplayPlayer();
                saveGame.Print(Colour.Orange, "[Press 'c' to change name, or ESC]", 43, 23);
                char keyPress = saveGame.Inkey();
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
            saveGame.SetBackground(BackgroundImage.Overhead);
            saveGame.Load();
            saveGame.FullScreenOverlay = false;
            saveGame.PrMapRedrawAction.Set();
            saveGame.PrEquippyRedrawAction.Set();
            saveGame.PrExtraRedrawAction.Set();
            saveGame.PrBasicRedrawAction.Set();
            saveGame.PrWipeRedrawAction.Set(); // TODO: special case ... should be some form of invalidate
            saveGame.HandleStuff();
        }
    }
}
