// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

/// <summary>
/// Represents the map of a single level.  Encapsulates all interactions so that changes to the map can be tracked.
/// </summary>
[Serializable]
internal class Map
{
    private readonly Game Game;
    public Map(Game game)
    {
        Game = game;
    }

    public readonly GridTile[][] Grid = new GridTile[Game.MaxHgt][];

    public void Initialize()
    {
        TrapsDetectedProperty trapsDetectedProperty = (TrapsDetectedProperty)Game.SingletonRepository.Get<Property>(nameof(TrapsDetectedProperty));
        Tile grassTile = Game.GetGrassTile;
        Tile dungeonFloorTile = Game.SingletonRepository.Get<Tile>(nameof(DungeonFloorTile));
        Tile towerFloorTile = Game.SingletonRepository.Get<Tile>(nameof(TowerFloorTile));
        Tile nothingTile = Game.SingletonRepository.Get<Tile>(nameof(NothingTile));
        bool isTower = Game.Wilderness[Game.WildernessY][Game.WildernessX].Dungeon.Tower;

        for (int y = 0; y < Game.MaxHgt; y++)
        {
            Grid[y] = new GridTile[Game.MaxWid];
            for (int x = 0; x < Game.MaxWid; x++)
            {
                GridTile newTile = new GridTile(trapsDetectedProperty, nothingTile, nothingTile);
                Grid[y][x] = newTile;
                if (Game.CurrentDepth == 0)
                {
                    newTile.SetBackgroundFeature(grassTile);
                }
                else if (isTower)
                {
                    newTile.SetBackgroundFeature(dungeonFloorTile);
                }
                else
                {
                    newTile.SetBackgroundFeature(dungeonFloorTile);
                }
            }
        }
    }
}
