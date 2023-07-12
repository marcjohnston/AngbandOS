// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts
{
    [Serializable]
    internal class ViewMapScript : Script
    {
        private ViewMapScript(SaveGame saveGame) : base(saveGame) { }

        public override bool Execute()
        {
            int cy = -1;
            int cx = -1;
            SaveGame.FullScreenOverlay = true;
            ScreenBuffer savedScreen = SaveGame.Screen.Clone();
            SaveGame.Screen.Clear();
            // If we're on the surface, display the island map
            if (SaveGame.CurrentDepth == 0)
            {
                SaveGame.SetBackground(BackgroundImageEnum.WildMap);
                SaveGame.DisplayWildMap();
            }
            else
            {
                // We're not on the surface, so draw the level map
                SaveGame.SetBackground(BackgroundImageEnum.Map);
                SaveGame.Level.DisplayMap(out cy, out cx);
            }
            // Give us a prompt, and display the cursor in the player's location
            SaveGame.Screen.Print(ColourEnum.Orange, "[Press any key to continue]", 43, 26);
            if (SaveGame.CurrentDepth == 0)
            {
                SaveGame.Screen.Goto(SaveGame.Player.WildernessY + 2, SaveGame.Player.WildernessX + 2);
            }
            else
            {
                SaveGame.Screen.Goto(cy, cx);
            }
            // Wait for a keypress, and restore the screen (looking at the map takes no time)
            SaveGame.Inkey();
            SaveGame.Screen.Restore(savedScreen);
            SaveGame.FullScreenOverlay = false;
            SaveGame.SetBackground(BackgroundImageEnum.Overhead);
            return false;
        }
    }
}
