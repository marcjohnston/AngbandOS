namespace AngbandOS.Core.ItemFilters;

/// <summary>
/// Represents an ItemFilter that filters out items that can be activated.
/// </summary>
internal class ActivatableItemFilter : ItemFilter
{
    public override bool ItemMatches(Item item)
    {
        if (!item.IsKnown())
        {
            return false;
        }
        item.RefreshFlagBasedProperties();
        return item.Characteristics.Activate;
    }
}
