namespace AngbandOS.Core.ItemFilters
{
    /// <summary>
    /// Represents an ItemFilter that filters out items that can fuel a lantern.
    /// </summary>
    internal class LanternFuelItemFilter : ItemFilter
    {
        public override bool ItemMatches(Item item)
        {
            if (item.Category == ItemTypeEnum.Flask)
            {
                return true;
            }
            if (item.Category == ItemTypeEnum.Light && item.ItemSubCategory == LightType.Lantern)
            {
                return true;
            }
            return false;
        }
    }
}
