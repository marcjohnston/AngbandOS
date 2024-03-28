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

}
