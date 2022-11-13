using AngbandOS.Enumerations;

namespace AngbandOS.Core.ItemFilters
{
    /// <summary>
    /// Represents an ItemFilter that filters items that can fuel a torch.
    /// </summary>
    internal class TorchFuelItemFilter : ItemFilter
    {
        public override bool ItemMatches(Item item)
        {
            return item.Category == ItemTypeEnum.Light && item.ItemSubCategory == LightType.Torch;
        }
    }
}
