using AngbandOS.Enumerations;

namespace AngbandOS.Core.ItemFilters
{
    /// <summary>
    /// Represents an ItemFilter that filters out armour items.
    /// </summary>
    internal class ArmourItemFilter : ItemCategoryItemFilter
    {
        public ArmourItemFilter() : base(ItemTypeEnum.DragArmor, ItemTypeEnum.HardArmor, ItemTypeEnum.SoftArmor, ItemTypeEnum.Shield, ItemTypeEnum.Cloak, ItemTypeEnum.Crown, ItemTypeEnum.Helm, ItemTypeEnum.Boots, ItemTypeEnum.Gloves)
        {
        }
    }
}
