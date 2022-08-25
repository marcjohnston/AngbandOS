using Cthangband.Enumerations;
using Cthangband.UI;
using System;

namespace Cthangband.Commands
{
    /// <summary>
    /// Locate the player on the level and let them scroll the map around
    /// </summary>
    [Serializable]
    internal class LocateCommand : ICommand
    {
        public char Key => 'L';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            int startRow = saveGame.Level.PanelRow;
            int startCol = saveGame.Level.PanelCol;
            int currentRow = startRow;
            int currentCol = startCol;
            TargetEngine targetEngine = new TargetEngine(saveGame);
            // Enter a loop so the player can browse the level
            while (true)
            {
                // Describe the location being viewed
                string offsetText;
                if (currentRow == startRow && currentCol == startCol)
                {
                    offsetText = "";
                }
                else
                {
                    string northSouth = currentRow < startRow ? " North" : currentRow > startRow ? " South" : "";
                    string eastWest = currentCol < startCol ? " West" : currentCol > startCol ? " East" : "";
                    offsetText = $"{northSouth}{eastWest} of";
                }
                string message = $"Map sector [{currentRow},{currentCol}], which is{offsetText} your sector. Direction?";
                // Get a direction command or escape
                int dir = 0;
                while (dir == 0)
                {
                    if (!saveGame.GetCom(message, out char command))
                    {
                        break;
                    }
                    dir = saveGame.GetKeymapDir(command);
                }
                if (dir == 0)
                {
                    break;
                }
                // Move the view based on the direction
                currentRow += saveGame.Level.KeypadDirectionYOffset[dir];
                currentCol += saveGame.Level.KeypadDirectionXOffset[dir];
                if (currentRow > saveGame.Level.MaxPanelRows)
                {
                    currentRow = saveGame.Level.MaxPanelRows;
                }
                else if (currentRow < 0)
                {
                    currentRow = 0;
                }
                if (currentCol > saveGame.Level.MaxPanelCols)
                {
                    currentCol = saveGame.Level.MaxPanelCols;
                }
                else if (currentCol < 0)
                {
                    currentCol = 0;
                }
                // Update the view if necessary
                if (currentRow != saveGame.Level.PanelRow || currentCol != saveGame.Level.PanelCol)
                {
                    saveGame.Level.PanelRow = currentRow;
                    saveGame.Level.PanelCol = currentCol;
                    targetEngine.PanelBounds();
                    saveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateMonsters);
                    saveGame.Player.RedrawNeeded.Set(RedrawFlag.PrMap);
                    saveGame.HandleStuff();
                }
            }
            // We've finished, so snap back to the player's location
            targetEngine.RecenterScreenAroundPlayer();
            saveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateMonsters);
            saveGame.Player.RedrawNeeded.Set(RedrawFlag.PrMap);
            saveGame.HandleStuff();
        }
    }
}
