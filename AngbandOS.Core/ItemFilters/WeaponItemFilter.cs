namespace AngbandOS.Core.ItemFilters;

/// <summary>
/// Represents an ItemFilter that filters out weapons.
/// </summary>
internal class WeaponItemFilter : ItemCategoryItemFilter
{
    public WeaponItemFilter() : base(ItemTypeEnum.Sword, ItemTypeEnum.Hafted, ItemTypeEnum.Polearm, ItemTypeEnum.Digging, ItemTypeEnum.Bow, ItemTypeEnum.Bolt, ItemTypeEnum.Arrow, ItemTypeEnum.Shot)
    {
    }
}
