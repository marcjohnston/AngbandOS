// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFilters;

/// <summary>
/// Represents an item filter for all corporeal books that have value.
/// </summary>
[Serializable]
internal class CorporealSpellBooksOfValueItemFilter : ItemFilter
{
    private CorporealSpellBooksOfValueItemFilter(Game game) : base(game) { } // This object is a singleton.
    protected override string[]? AnyMatchingItemClassNames => new string[]
        {
            Game.SingletonRepository.Get<ItemClass>(nameof(CorporealSpellBooksItemClass)).Key
        };
    public override bool? IsOfValue => true;
}
