// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Represents an item filter for all amulets of value.
/// </summary>
[Serializable]
public class AmuletsOfValueItemFilter : ItemFilterGameConfiguration
{
    public override bool? IsOfValue => true;
    public override string[]? AnyMatchingItemClassNames => new string[]
    {
        nameof(AmuletsItemClass)
    };
}