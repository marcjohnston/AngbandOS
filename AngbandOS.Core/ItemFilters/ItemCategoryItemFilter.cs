using AngbandOS.Enumerations;

namespace AngbandOS.Core.ItemFilters
{
    /// <summary>
    /// Represents an ItemFilter object that returns true, if an Item is of any specific ItemCategory.
    /// </summary>
    internal class ItemCategoryItemFilter : AngbandOS.Core.ItemFilters.ItemFilter
    {
        public override bool ItemMatches(Item item)
        {
            foreach (ItemCategory itemCategory in ItemCategories)
            {
                if (item.Category == itemCategory)
                    return true;
            }
            return false;
        }

        private ItemCategory[] ItemCategories { get; }

        public ItemCategoryItemFilter(params ItemCategory[] itemCategories)
        {
            ItemCategories = itemCategories;
        }
    }
}
