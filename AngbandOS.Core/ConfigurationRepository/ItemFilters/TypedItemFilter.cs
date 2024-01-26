// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFilters;

[Serializable]
internal abstract class ItemFilter<TItemFactory> : ItemFilter where TItemFactory : ItemFactory
{
    protected ItemFilter(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public virtual string? ItemFactoryName => null;
    public override bool ItemMatches(Item item)
    {
        // Check that the item came from the same item factory.
        if (item.Factory != null && item.Factory is not TItemFactory)
        {
            return false;
        }

        // Check the base matching criteria.
        return base.ItemMatches(item);
    }
}
