// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

/// <summary>
/// Get a direction and bash a door, returning true, if the command can be repeated; false, if the command succeeds or is futile.</returns>
/// </summary>
[Serializable]
internal class BashScript : Script, IScript, IRepeatableScript
{
    private BashScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the bash script and disposes of the repeatable result.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteRepeatableScript();
    }

    /// <summary>
    /// Allows the player to select a direction and bashes the object found in that direction.  Returns true, if the action fails due to chance.
    /// </summary>
    /// <returns></returns>
    public RepeatableResult ExecuteRepeatableScript()
    {
        // Assume it won't disturb us
        bool isRepeatable = false;

        // Get the direction to bash
        if (Game.GetDirectionNoAim(out int dir))
        {
            int y = Game.MapY.IntValue + Game.KeypadDirectionYOffset[dir];
            int x = Game.MapX.IntValue + Game.KeypadDirectionXOffset[dir];
            GridTile tile = Game.Map.Grid[y][x];
            // Can only bash closed doors
            if (!tile.FeatureType.IsVisibleDoor)
            {
                Game.MsgPrint("You see nothing there to bash.");
            }
            else if (tile.MonsterIndex != 0)
            {
                // Oops - a monster got in the way
                Game.EnergyUse = 100;
                Game.MsgPrint("There is a monster in the way!");
                Game.PlayerAttackMonster(y, x);
            }
            else
            {
                // Bash the door.
                isRepeatable = Game.BashClosedDoor(y, x);
            }
        }
        return new RepeatableResult(isRepeatable);
    }
}