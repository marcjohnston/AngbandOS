// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.TileCategories;

[Serializable]
internal abstract class TileCategory
{
    protected readonly SaveGame SaveGame;
    protected TileCategory(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    [Obsolete("For backwards compatability only")]
    public virtual FloorTileTypeCategory CategoryEnum => FloorTileTypeCategory.Other;
}
