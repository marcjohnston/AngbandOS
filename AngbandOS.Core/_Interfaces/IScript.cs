// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Interfaces;

/// <summary>
/// Represents the interface a void return value script needs to implement to be run without any parameters.
/// </summary>
internal interface IScript
{
    /// <summary>
    /// Execute the script.
    /// </summary>
    /// <returns></returns>
    void ExecuteScript();
}
