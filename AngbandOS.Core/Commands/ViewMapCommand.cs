using AngbandOS.Core.Interface;
using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.Commands
{
    /// <summary>
    /// Display a map of the area on screen
    /// </summary>
    [Serializable]
    internal class ViewMapCommand : ICommand
    {
        public char Key => 'M';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            int cy = -1;
            int cx = -1;
            saveGame.FullScreenOverlay = true;
            saveGame.SaveScreen();
            saveGame.Clear();
            // If we're on the surface, display the island map
            if (saveGame.CurrentDepth == 0)
            {
                saveGame.SetBackground(BackgroundImage.WildMap);
                saveGame.DisplayWildMap();
            }
            else
            {
                // We're not on the surface, so draw the level map
                saveGame.SetBackground(BackgroundImage.Map);
                saveGame.Level.DisplayMap(out cy, out cx);
            }
            // Give us a prompt, and display the cursor in the player's location
            saveGame.Print(Colour.Orange, "[Press any key to continue]", 43, 26);
            if (saveGame.CurrentDepth == 0)
            {
                saveGame.Goto(saveGame.Player.WildernessY + 2, saveGame.Player.WildernessX + 2);
            }
            else
            {
                saveGame.Goto(cy, cx);
            }
            // Wait for a keypress, and restore the screen (looking at the map takes no time)
            saveGame.Inkey();
            saveGame.Load();
            saveGame.FullScreenOverlay = false;
            saveGame.SetBackground(BackgroundImage.Overhead);
        }
    }
}
