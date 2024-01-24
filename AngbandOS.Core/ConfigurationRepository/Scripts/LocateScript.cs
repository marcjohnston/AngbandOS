// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class LocateScript : Script, IScript, IRepeatableScript
{
    private LocateScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the locate script and returns false.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteRepeatableScript()
    {
        ExecuteScript();
        return false;
    }

    /// <summary>
    /// Executes the locate script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        int startRow = SaveGame.PanelRow;
        int startCol = SaveGame.PanelCol;
        int currentRow = startRow;
        int currentCol = startCol;

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
                if (!SaveGame.GetCom(message, out char command))
                {
                    break;
                }
                dir = SaveGame.GetKeymapDir(command);
            }
            if (dir == 0)
            {
                break;
            }

            // Move the view based on the direction
            currentRow += SaveGame.KeypadDirectionYOffset[dir];
            currentCol += SaveGame.KeypadDirectionXOffset[dir];
            if (currentRow > SaveGame.MaxPanelRows)
            {
                currentRow = SaveGame.MaxPanelRows;
            }
            else if (currentRow < 0)
            {
                currentRow = 0;
            }
            if (currentCol > SaveGame.MaxPanelCols)
            {
                currentCol = SaveGame.MaxPanelCols;
            }
            else if (currentCol < 0)
            {
                currentCol = 0;
            }

            // Update the view if necessary
            if (currentRow != SaveGame.PanelRow || currentCol != SaveGame.PanelCol)
            {
                SaveGame.PanelRow = currentRow;
                SaveGame.PanelCol = currentCol;
                SaveGame.PanelBounds();
                SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateMonstersFlaggedAction)).Set();
                SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawMapFlaggedAction)).Set();
                SaveGame.HandleStuff();
            }
        }

        // We've finished, so snap back to the player's location
        SaveGame.RecenterScreenAroundPlayer();
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateMonstersFlaggedAction)).Set();
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawMapFlaggedAction)).Set();
        SaveGame.HandleStuff();
    }
}
