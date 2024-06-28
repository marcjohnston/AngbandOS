// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFilters;

/// <summary>
/// Returns an item filter for all bolts that have value.
/// </summary>
[Serializable]
internal class BoltsOfValueItemFilter : ItemFilter
{
    private BoltsOfValueItemFilter(Game game) : base(game) { } // This object is a singleton.
    public override string[]? AnyMatchingFactoryItemClassKeys => new string[]
        {
            Game.SingletonRepository.Get<ItemClass>(nameof(BoltsItemClass)).Key
        };
    public override bool? IsOfValue => true;
}
