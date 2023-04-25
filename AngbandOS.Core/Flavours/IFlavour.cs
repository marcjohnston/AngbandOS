namespace AngbandOS.Core.Flavours
{
    /// <summary>
    /// Represents an interface for an item that idenitems that are identified as "flavours".  The item is identified to the player with some "flavour" and the player needs to identify the
    /// actual item.
    /// </summary>
    internal interface IFlavour
    {
        void ApplyFlavourVisuals();

        /// <summary>
        /// Returns the repository for which items will receive their flavour from.
        /// </summary>
        IEnumerable<Flavour> Flavours { get; }
    }
}