namespace AngbandOS.Core.ItemFilters;

/// <summary>
/// Represents an ItemFilter that filters out items that can fuel a lantern.
/// </summary>
internal class LanternFuelItemFilter : ItemFilter
{
    public override bool ItemMatches(Item item)
    {
        return item.Factory.IsFuelForLantern;
    }
}
