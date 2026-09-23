// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

/// <summary>
/// Returns whether or not an action was noticed by the player.
/// </summary>
public enum IsNoticedEnum
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
