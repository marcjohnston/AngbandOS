// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class CloseScript : GameCommandUniversalScript, IGetKey
{
    private CloseScript(Game game) : base(game) { }

    /// <summary>
    /// Returns the entity serialized into a Json string.  Returns an empty string by default.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        return "";
    }

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }

    /// <summary>
    /// Count the number of open doors around the players location, puting the location of the
    /// last one found into a map coordinate
    /// </summary>
    /// <param name="mapCoordinate">
    /// The map coordinate into which the location should be placed
    /// </param>
    /// <returns> The number of open doors found </returns>
    private int CountOpenDoors(out GridCoordinate? mapCoordinate)
    {
        int count = 0;
        mapCoordinate = null;
        for (int orderedDirection = 0; orderedDirection < 9; orderedDirection++)
        {
            int yy = Game.MapY.IntValue + Game.OrderedDirectionYOffset[orderedDirection];
            int xx = Game.MapX.IntValue + Game.OrderedDirectionXOffset[orderedDirection];
            // We must be aware of the door
            if (!Game.Map.Grid[yy][xx].PlayerMemorized)
            {
                continue;
            }
            // It must actually be an open door
            if (!Game.Map.Grid[yy][xx].FeatureType.CanBeClosed)
            {
                continue;
            }
            count++;
            // Remember the location
            mapCoordinate = new GridCoordinate(xx, yy);
        }
        return count;
    }

    /// <summary>
    /// Executes the close script and returns true, if the close failed due to chance; false, otherwise.
    /// </summary>
    /// <returns></returns>
    public override RepeatableResultEnum ExecuteGameCommandScript()
    {
        bool isRepeatable = false;
        // If there's only one door, assume we mean that one and don't ask for a direction
        if (CountOpenDoors(out GridCoordinate? coord) == 1)
        {
            Game.CommandDirection = Game.CoordsToDir(coord.Y, coord.X);
        }
        // Get the location to close
        if (Game.GetDirectionNoAim(out int dir))
        {
            int y = Game.MapY.IntValue + Game.KeypadDirectionYOffset[dir];
            int x = Game.MapX.IntValue + Game.KeypadDirectionXOffset[dir];
            GridTile tile = Game.Map.Grid[y][x];
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
                isRepeatable = Game.CloseDoor(y, x);
            }
        }
        return isRepeatable ? RepeatableResultEnum.True : RepeatableResultEnum.False;
    }
}
