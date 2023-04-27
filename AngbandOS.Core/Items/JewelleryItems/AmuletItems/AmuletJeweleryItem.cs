namespace AngbandOS.Core.Items
{
    [Serializable]
    internal abstract class AmuletJeweleryItem : JewelleryItem
    {
        public override int WieldSlot => InventorySlot.Neck;
        public AmuletJeweleryItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }

        /// <summary>
        /// Returns the factory that this item was created by; casted as an IFlavour.
        /// </summary>
        public IFlavour FlavourFactory => (IFlavour)Factory;

        public override string GetDescription(bool includeCountPrefix)
        {
            if (FixedArtifact != null && IsFlavourAware())
            {
                return base.GetDescription(includeCountPrefix);
            }
            string flavour = IdentStoreb ? "" : $"{FlavourFactory.Flavour.Name} ";
            string ofName = IsFlavourAware() ? $" of {Factory.FriendlyName}" : "";
            string name = $"{flavour}{Pluralize("Amulet", Count)}{ofName}";
            return includeCountPrefix ? GetPrefixCount(true, name, Count, IsKnownArtifact) : name;
        }
    }
}