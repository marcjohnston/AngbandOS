using AngbandOS.Enumerations;

namespace AngbandOS.Core.ItemFilters
{
    /// <summary>
    /// Represents an ItemFilter that filters out armour items.
    /// </summary>
    internal class ArmourItemFilter : ItemCategoryItemFilter
    {
        public ArmourItemFilter() : base(ItemCategory.DragArmor, ItemCategory.HardArmor, ItemCategory.SoftArmor, ItemCategory.Shield, ItemCategory.Cloak, ItemCategory.Crown, ItemCategory.Helm, ItemCategory.Boots, ItemCategory.Gloves)
        {
        }
    }
}
