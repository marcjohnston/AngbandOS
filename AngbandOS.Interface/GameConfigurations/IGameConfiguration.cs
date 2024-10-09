// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Interface;

/// <summary>
/// Represents the interface a configuration object need to implement to store user configurable settings for initializing game objects.
/// </summary>
public interface IGameConfiguration
{
    /// <summary>
    /// Returns true, if the supplied values are valid; false, otherwise.
    /// </summary>
    /// <returns></returns>
    bool IsValid();
}
