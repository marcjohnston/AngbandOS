// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class LocateScript : Script, IScript, ICastSpellScript, IGameCommandScript
{
    private LocateScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Returns information about the script, or blank if there is no detailed information.  Returns blank, by default.
    /// </summary>
    public string LearnedDetails => "";

    /// <summary>
    /// Executes the locate script and returns false.
    /// </summary>
    /// <returns></returns>
    public RepeatableResult ExecuteGameCommandScript()
    {
        ExecuteScript();
        return new RepeatableResult(false);
    }

    /// <summary>
    /// Executes the locate script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        int startRow = Game.PanelRow;
        int startCol = Game.PanelCol;
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
                if (!Game.GetCom(message, out char command))
                {
                    break;
                }
                dir = Game.GetKeymapDir(command);
            }
            if (dir == 0)
            {
                break;
            }

            // Move the view based on the direction
            currentRow += Game.KeypadDirectionYOffset[dir];
            currentCol += Game.KeypadDirectionXOffset[dir];
            if (currentRow > Game.MaxPanelRows)
            {
                currentRow = Game.MaxPanelRows;
            }
            else if (currentRow < 0)
            {
                currentRow = 0;
            }
            if (currentCol > Game.MaxPanelCols)
            {
                currentCol = Game.MaxPanelCols;
            }
            else if (currentCol < 0)
            {
                currentCol = 0;
            }

            // Update the view if necessary
            if (currentRow != Game.PanelRow || currentCol != Game.PanelCol)
            {
                Game.PanelRow = currentRow;
                Game.PanelCol = currentCol;
                Game.PanelRowMin = Game.PanelRow * (Constants.PlayableScreenHeight / 2);
                Game.PanelRowMax = Game.PanelRowMin + Constants.PlayableScreenHeight - 1;
                Game.PanelColMin = Game.PanelCol * (Constants.PlayableScreenWidth / 2);
                Game.PanelColMax = Game.PanelColMin + Constants.PlayableScreenWidth - 1;
                Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateMonstersFlaggedAction)).Set();
                Game.RefreshMap.SetChangedFlag(); // TODO: Needs to convert to dependencies in the MapWidget
                Game.HandleStuff();
            }
        }

        // We've finished, so snap back to the player's location
        Game.RecenterScreenAroundPlayer();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateMonstersFlaggedAction)).Set();
        Game.RefreshMap.SetChangedFlag(); // TODO: Needs to convert to dependencies in the MapWidget
        Game.HandleStuff();
    }
}
