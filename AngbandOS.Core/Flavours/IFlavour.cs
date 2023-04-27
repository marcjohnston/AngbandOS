namespace AngbandOS.Core.Flavours
{
    /// <summary>
    /// Represents the interface an item factory needs to implement for the item to have a flavour.
    /// </summary>
    internal interface IFlavour
    {
        /// <summary>
        /// Returns the repository to use for the issuance of the flavours.
        /// </summary>
        IEnumerable<Flavour> Flavours { get; }

        /// <summary>
        /// Returns the flavour that was issued to the item factory.
        /// </summary>
        Flavour Flavour { get; set; }
    }
}