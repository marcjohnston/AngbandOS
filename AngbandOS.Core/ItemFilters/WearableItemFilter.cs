namespace AngbandOS.Core.ItemFilters;

/// <summary>
/// Represents an ItemFilter that filters items that can be worn or wielded.
/// </summary>
internal class WearableItemFilter : ItemCategoryItemFilter
{
    public WearableItemFilter() : base(ItemTypeEnum.DragArmor, ItemTypeEnum.HardArmor, ItemTypeEnum.SoftArmor, ItemTypeEnum.Shield, ItemTypeEnum.Cloak, ItemTypeEnum.Crown, ItemTypeEnum.Helm, ItemTypeEnum.Boots, ItemTypeEnum.Gloves, ItemTypeEnum.Sword, ItemTypeEnum.Hafted, ItemTypeEnum.Polearm, ItemTypeEnum.Digging, ItemTypeEnum.Bow, ItemTypeEnum.Ring, ItemTypeEnum.Amulet, ItemTypeEnum.Light)
    {
    }
}
