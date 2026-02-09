// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

/// <summary>
/// Represents the base class for an attribute value.  There are two flavors: readonly; which maintains a single immutable value and effective; which maintains an algorithmic non-immutable value.
/// </summary>
[Serializable]
internal abstract class AttributeValue
{
}
