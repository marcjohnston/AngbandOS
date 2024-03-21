// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class CloseScript : Script, IScript, IRepeatableScript
{
    private CloseScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the close script and disposes of the repeatable result.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteRepeatableScript();
    }

    /// <summary>
    /// Executes the close script and returns true, if the close failed due to chance; false, otherwise.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteRepeatableScript()
    {
        bool more = false;
        // If there's only one door, assume we mean that one and don't ask for a direction
        if (Game.CountOpenDoors(out GridCoordinate? coord) == 1)
        {
            Game.CommandDirection = Game.CoordsToDir(coord.Y, coord.X);
        }
        // Get the location to close
        if (Game.GetDirectionNoAim(out int dir))
        {
            int y = Game.MapY + Game.KeypadDirectionYOffset[dir];
            int x = Game.MapX + Game.KeypadDirectionXOffset[dir];
            GridTile tile = Game.Grid[y][x];
            // Can only close actual open doors
            if (!tile.FeatureType.IsOpenDoor)
            {
                Game.MsgPrint("You see nothing there to close.");
            }
            // Can't close if there's a monster in the way
            else if (tile.MonsterIndex != 0)
            {
                Game.EnergyUse = 100;
                Game.MsgPrint("There is a monster in the way!");
                Game.PlayerAttackMonster(y, x);
            }
            // Actually close the door
            else
            {
                more = Game.CloseDoor(y, x);
            }
        }
        return more;
    }
}
