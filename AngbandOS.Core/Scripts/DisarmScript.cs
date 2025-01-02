// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class DisarmScript : Script, IScript, IRepeatableScript
{
    private DisarmScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the disarm script and disposes of the repeatable result.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteRepeatableScript();
    }

    /// <summary>
    /// Executes the disarm script and returns true, if the disarm fails due to chance; false, otherwise.
    /// </summary>
    /// <returns></returns>
    public RepeatableResult ExecuteRepeatableScript()
    {
        bool isRepeatable = false;
        int numTraps = Game.CountKnownTraps(out GridCoordinate? trapCoord);
        int numChests = Game.CountChests(out GridCoordinate? chestCoord, true);
        // Count the possible traps and chests we might want to disarm
        if (numTraps != 0 || numChests != 0)
        {
            bool tooMany = (numTraps != 0 && numChests != 0) || numTraps > 1 || numChests > 1;
            // If only one then we have our target
            if (!tooMany)
            {
                GridCoordinate coord = numTraps == 1 ? trapCoord : chestCoord;
                Game.CommandDirection = Game.CoordsToDir(coord.Y, coord.X);
            }
        }
        // Get a direction if we don't already have one
        if (Game.GetDirectionNoAim(out int dir))
        {
            int y = Game.MapY.IntValue + Game.KeypadDirectionYOffset[dir];
            int x = Game.MapX.IntValue + Game.KeypadDirectionXOffset[dir];
            GridTile tile = Game.Map.Grid[y][x];
            // Check for a chest
            Item? chestItem = Game.ChestCheck(y, x);
            if (!tile.FeatureType.IsTrap && chestItem == null)
            {
                Game.MsgPrint("You see nothing there to disarm.");
            }
            // Can't disarm with a monster in the way
            else if (tile.MonsterIndex != 0)
            {
                Game.MsgPrint("There is a monster in the way!");
                Game.PlayerAttackMonster(y, x);
            }
            // Disarm the chest or trap
            else if (chestItem != null)
            {
                isRepeatable = Game.DisarmChest(y, x, chestItem);
            }
            else
            {
                isRepeatable = Game.DisarmTrap(y, x);
            }
        }
        return new RepeatableResult(isRepeatable);
    }
}
