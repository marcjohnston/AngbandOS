using AngbandOS.Enumerations;

namespace AngbandOS.Core.ItemFilters
{
    /// <summary>
    /// Represents an ItemFilter that filters out weapons.
    /// </summary>
    internal class WeaponItemFilter : ItemCategoryItemFilter
    {
        public WeaponItemFilter() : base(ItemCategory.Sword, ItemCategory.Hafted, ItemCategory.Polearm, ItemCategory.Digging, ItemCategory.Bow, ItemCategory.Bolt, ItemCategory.Arrow, ItemCategory.Shot)
        {
        }
    }
}
