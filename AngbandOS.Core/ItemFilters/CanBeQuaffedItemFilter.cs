// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFilters;

/// <summary>
/// Represents an item filter for items that can be quaffed, regardless of their value.
/// </summary>
[Serializable]
internal class CanBeQuaffedItemFilter : ItemFilter
{
    private CanBeQuaffedItemFilter(Game game) : base(game) { } // This object is a singleton.

    public override bool? CanBeQuaffed => true;
}