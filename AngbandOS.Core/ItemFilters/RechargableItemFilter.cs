using AngbandOS.Enumerations;

namespace AngbandOS.Core.ItemFilters
{
    internal class RechargableItemFilter : ItemCategoryItemFilter
    {
        public RechargableItemFilter() : base(ItemCategory.Staff, ItemCategory.Wand, ItemCategory.Rod)
        {
        }
    }
}
