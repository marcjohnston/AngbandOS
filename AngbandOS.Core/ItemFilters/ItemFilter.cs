namespace AngbandOS.Core.ItemFilters;

/// <summary>
/// Represents an object that performs item filtering.
/// </summary>
internal abstract class ItemFilter : IItemFilter
{
    /// <inheritdoc/>
    public abstract bool ItemMatches(Item item);
}
