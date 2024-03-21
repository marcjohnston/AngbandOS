// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Interfaces;

/// <summary>
/// Represents an interface an object needs to implement to be a monster filter.  The MonsterFilter singletons all implement
/// this interface along with a handful of "dynamic" monster filters (DynamicMonsterFilter).  Those objects cannot be used as
/// singletons because they accept a parameter during construction that is used for the monster matching (like kin, place okay
/// and clone).
/// </summary>
internal interface IMonsterFilter
{
    /// <summary>
    /// Returns true, if a monster matches the selector.
    /// </summary>
    /// <param name="game"></param>
    /// <param name="rPtr">The monster race to check.</param>
    /// <returns></returns>
    bool Matches(MonsterRace rPtr);
}