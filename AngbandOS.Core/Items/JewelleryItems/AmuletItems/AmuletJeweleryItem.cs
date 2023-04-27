namespace AngbandOS.Core.Items
{
    [Serializable]
    internal abstract class AmuletJeweleryItem : JewelleryItem
    {
        public override int WieldSlot => InventorySlot.Neck;
        public AmuletJeweleryItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        public override string GetDescription(bool includeCountPrefix)
        {
            if (FixedArtifact != null && IsFlavourAware())
            {
                return base.GetDescription(includeCountPrefix);
            }
            string flavour = IdentStoreb ? "" : $"{SaveGame.SingletonRepository.AmuletFlavours[ItemSubCategory].Name} ";
            string ofName = IsFlavourAware() ? $" of {Factory.FriendlyName}" : "";
            string name = $"{flavour}{Pluralize("Amulet", Count)}{ofName}";
            return includeCountPrefix ? GetPrefixCount(true, name, Count, IsKnownArtifact) : name;
        }
    }
}