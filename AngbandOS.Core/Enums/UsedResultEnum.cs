// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

/// <summary>
/// Represents whether or not an action was cancelled or an item was used.
/// </summary>
public enum UsedResultEnum
{
    /// <summary>
    /// Represents an action that was not cancelled and that the item was used.
    /// </summary>
    True,

    /// <summary>
    /// Represents an action that was cancelled or that the item was not used.
    /// </summary>
    False
}
