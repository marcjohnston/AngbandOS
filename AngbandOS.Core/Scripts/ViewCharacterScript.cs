// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts
{
    [Serializable]
    internal class ViewCharacterScript : Script
    {
        private ViewCharacterScript(SaveGame saveGame) : base(saveGame) { }

        public override bool Execute()
        {
            // Save the current screen
            SaveGame.FullScreenOverlay = true;
            ScreenBuffer savedScreen = SaveGame.Screen.Clone();
            SaveGame.SetBackground(BackgroundImageEnum.Paper);
            // Load the character viewer
            while (!SaveGame.Shutdown)
            {
                RenderCharacterScript showCharacterSheet = SaveGame.SingletonRepository.Scripts.Get<RenderCharacterScript>();
                showCharacterSheet.Execute();
                SaveGame.Screen.Print(ColourEnum.Orange, "[Press 'c' to change name, or ESC]", 43, 23);
                char keyPress = SaveGame.Inkey();
                // Escape breaks us out of the loop
                if (keyPress == '\x1b')
                {
                    break;
                }
                // 'c' changes name
                if (keyPress == 'c' || keyPress == 'C')
                {
                    SaveGame.Player.InputPlayerName();
                }
                SaveGame.MsgPrint(null);
            }
            // Restore the screen
            SaveGame.SetBackground(BackgroundImageEnum.Overhead);
            SaveGame.Screen.Restore(savedScreen);
            SaveGame.FullScreenOverlay = false;
            SaveGame.RedrawMapFlaggedAction.Set();
            SaveGame.RedrawEquippyFlaggedAction.Set();
            SaveGame.PrExtraRedrawAction.Set();
            SaveGame.PrBasicRedrawAction.Set();
            SaveGame.RedrawAllFlaggedAction.Set(); // TODO: special case ... should be some form of invalidate
            SaveGame.HandleStuff();
            return false;
        }
    }
}
