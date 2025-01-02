// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Interfaces;

internal interface IReadScrollAndUseStaffScript
{
    /// <summary>
    /// Returns identified as true, if the script performs an action that would identify the item; false, otherwise and used as true, if the item should be deleted; false, for the item to be kept.
    /// </summary>
    /// <returns></returns>
    IdentifiedAndUsedResult ExecuteReadScrollAndUseStaffScript(); // TODO: Why isn't there an Item parameter like IZapRodScript
}
