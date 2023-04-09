namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class AmuletItemClass : JewelleryItemClass
    {
        public AmuletItemClass(SaveGame saveGame) : base(saveGame) { }
        public override BaseInventorySlot BaseWieldSlot => SaveGame.SingletonRepository.InventorySlots.Get<NeckInventorySlot>();
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Amulet;
        public override string GetDescription(Item item, bool includeCountPrefix)
        {
            if (item.FixedArtifact != null && item.IsFlavourAware())
            {
                return base.GetDescription(item, includeCountPrefix);
            }
            string flavour = item.IdentStoreb ? "" : $"{item.SaveGame.SingletonRepository.AmuletFlavours[item.ItemSubCategory].Name} ";
            string ofName = item.IsFlavourAware() ? $" of {item.Factory.FriendlyName}" : "";
            string name = $"{flavour}{Pluralize("Amulet", item.Count)}{ofName}";
            return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
        }
        public override int BaseValue => 45;
        public override Colour Colour => Colour.Orange;
        public override int? SubCategory => null; // All amulet subcategories have been refactored.
        public override bool HasFlavor => true;
    }
}
