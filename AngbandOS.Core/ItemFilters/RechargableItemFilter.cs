namespace AngbandOS.Core.ItemFilters;

internal class RechargableItemFilter : ItemCategoryItemFilter
{
    public RechargableItemFilter() : base(ItemTypeEnum.Staff, ItemTypeEnum.Wand, ItemTypeEnum.Rod)
    {
    }
}
