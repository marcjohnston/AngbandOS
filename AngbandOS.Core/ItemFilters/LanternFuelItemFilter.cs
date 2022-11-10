using AngbandOS.Enumerations;

namespace AngbandOS.Core.ItemFilters
{
    /// <summary>
    /// Represents an ItemFilter that filters out items that can fuel a lantern.
    /// </summary>
    internal class LanternFuelItemFilter : ItemFilter
    {
        public override bool ItemMatches(Item item)
        {
            if (item.Category == ItemCategory.Flask)
            {
                return true;
            }
            if (item.Category == ItemCategory.Light && item.ItemSubCategory == LightType.Lantern)
            {
                return true;
            }
            return false;
        }
    }
}
