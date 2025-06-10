// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class WildernessRegion
{
    /// <summary>
    /// Returns the dungeon that is located in this region; or null, if there is none.
    /// </summary>
    public Dungeon? Dungeon = null;

    /// <summary>
    /// Returns the town that is located in this region; or null, if there is none.
    /// </summary>
    public Town? Town = null;

    public int RoadMap = 0;
    public int Seed = 0;
}