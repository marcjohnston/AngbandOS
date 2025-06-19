// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Represents an item filter for potions that have value.
/// </summary>
[Serializable]
public class PotionsOfValueItemFilter : ItemFilterGameConfiguration
{
    public override string[]? AnyMatchingItemClassNames => new string[]
        {
            nameof(PotionsItemClass)
        };
    public override bool? IsOfValue => true;
}
