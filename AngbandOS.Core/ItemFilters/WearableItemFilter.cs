using AngbandOS.Enumerations;

namespace AngbandOS.Core.ItemFilters
{
    /// <summary>
    /// Represents an ItemFilter that filters items that can be worn or wielded.
    /// </summary>
    internal class WearableItemFilter : ItemCategoryItemFilter
    {
        public WearableItemFilter() : base(ItemCategory.DragArmor, ItemCategory.HardArmor, ItemCategory.SoftArmor, ItemCategory.Shield, ItemCategory.Cloak, ItemCategory.Crown, ItemCategory.Helm, ItemCategory.Boots, ItemCategory.Gloves, ItemCategory.Sword, ItemCategory.Hafted, ItemCategory.Polearm, ItemCategory.Digging, ItemCategory.Bow, ItemCategory.Ring, ItemCategory.Amulet, ItemCategory.Light)
        {
        }
    }
}
