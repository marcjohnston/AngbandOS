using AngbandOS.Enumerations;

namespace AngbandOS.Core.ItemFilters
{
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

        private ItemTypeEnum[] ItemCategories { get; }

        public ItemCategoryItemFilter(params ItemTypeEnum[] itemCategories)
        {
            ItemCategories = itemCategories;
        }
    }
}
