// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Interfaces;

/// <summary>
/// Represents an interface that an object must implement to handle ItemFiltering.  ItemFilters and stores implement this interface.
/// </summary>
internal interface IItemFilter
{
    /// <summary>
    /// Returns whether or not an item matches the desired filter.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    bool Matches(Item item);
}
