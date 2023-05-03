namespace AngbandOS.Core.Flavours
{
    /// <summary>
    /// Represents the interface an item factory needs to implement for the item to have a flavour.
    /// </summary>
    internal interface IFlavour
    {
        /// <summary>
        /// Returns the repository to use for the issuance of the flavours or null, if the factory shouldn't be issued a flavour.  Null is returned
        /// when an item has a predefined flavour.  Apple juice, water and slime-mold item factories use pre-defined flavours. 
        /// </summary>
        IEnumerable<Flavour>? GetFlavourRepository();

        /// <summary>
        /// Returns the flavour that was issued to the item factory.
        /// </summary>
        Flavour Flavour { get; set; }
    }
}