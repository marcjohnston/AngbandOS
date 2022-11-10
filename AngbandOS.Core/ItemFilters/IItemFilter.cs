namespace AngbandOS.Core.ItemFilters
{
    /// <summary>
    /// Represents an interface that an object must implement to handle ItemFiltering.  ItemFilters and stores implement this interface.
    /// </summary>
    internal interface IItemFilter
    {
        /// <summary>
        /// Returns whether or not an item matches the desired filter.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool ItemMatches(Item item);
    }
}
