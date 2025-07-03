// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Interfaces;

/// <summary>
/// Represents an interface for item enhancements.  This interface is used by the ItemEnhancementWeightedRandom so that it qualifies as an item enhancement.
/// </summary>
internal interface IItemEnhancement
{
    ItemEnhancement? GetItemEnhancement();
}

