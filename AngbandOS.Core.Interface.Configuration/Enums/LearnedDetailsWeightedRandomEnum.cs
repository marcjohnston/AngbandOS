// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Interface.Configuration;

/// <summary>
/// Represents how learned details should be returned.
/// </summary>
public enum LearnedDetailsWeightedRandomEnum
{
    /// <summary>
    /// Represents using the LearnedDetails property.
    /// </summary>
    Default,

    /// <summary>
    /// Represents returning the learned details from the first item.
    /// </summary>
    InheritFromFirstDefined
}