// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFilters;

/// <summary>
/// Represents an ItemFilter object that returns true, if an Item is of any specific ItemCategory.
/// </summary>
internal class ItemCategoryItemFilter : ItemFilter
{
    public override bool ItemMatches(Item item)
    {
        foreach (ItemTypeEnum itemCategory in ItemCategories)
        {
            if (item.Category == itemCategory)
                return true;
        }
        return false;
    }

    protected List<ItemTypeEnum> ItemCategories = new List<ItemTypeEnum>();

    public ItemCategoryItemFilter(params ItemTypeEnum[] itemCategories)
    {
        ItemCategories.AddRange(itemCategories);
    }
}
