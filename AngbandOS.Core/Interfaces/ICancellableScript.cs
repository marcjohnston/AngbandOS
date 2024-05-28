// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Interfaces;

internal interface ICancellableScript
{
    /// <summary>
    /// Run the associated script and return false, if the script is cancelled; true, otherwise.  A script is considered to have been run if it fails by chance.  A script is considered cancelled
    /// if the player doesn't have an item for the script to run against, or the player cancels an item or other selection.
    /// </summary>
    /// <returns></returns>
    bool ExecuteCancellableScript();
}
