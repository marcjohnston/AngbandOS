// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Interfaces;

/// <summary>
/// Represents the interface that a script needs to implement to particpate in scripts that return an IdentifiedResult if the action it performs can by identify by the player.
/// This interface is used by:
/// 1. Eat
/// 2. Quaff
/// </summary>
internal interface IEatOrQuaffScript
{ 
    /// <summary>
    /// Returns true, if the script performs an action that would identify the item; false, otherwise. 
    /// </summary>
    /// <returns></returns>
    IdentifiedResultEnum ExecuteEatOrQuaffScript();
}
