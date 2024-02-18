// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

/// <summary>
/// Represents the interface a script needs to implement to particpate in repeatable scripts.  In-game player commands must implement this interface.  Store commands and
/// wizard commands do not require this interface.
/// </summary>
internal interface IRepeatableScript
{
    /// <summary>
    /// Returns true, if the script can be repeated.  The ability to repeat a command should be determined by whether or not the script failed due to chance or was successful.  
    /// Scripts that fail due to chance can return true, to allow the player to auto-repeat the command (e.g. bash a door).
    /// Scripts that succeed and can have additional effect if repeated should also return true.  (e.g. run)
    /// </summary>
    /// <returns></returns>
    bool ExecuteRepeatableScript();
}
