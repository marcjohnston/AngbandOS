// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

/// <summary>
/// Represents whether or not an item was identified.
/// </summary>
public enum IdentifiedResultEnum
{
    /// <summary>
    /// The action or item has been identified or "noticed".
    /// </summary>
    True,

    /// <summary>
    /// The action or item has not been identified or "noticed".
    /// </summary>
    False
}
