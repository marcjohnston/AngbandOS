namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RingPower : RingItemClass
    {
        private RingPower(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '=';
        public override Colour Colour => Colour.Yellow;
        public override string Name => "Power";

        public override int Cost => 5000000;
        public override string FriendlyName => "& Ring~"; // TODO: This appears to cause a defect in identification
        public override bool InstaArt => true;
        public override int Level => 110;
        public override int? SubCategory => 37;
        public override int Weight => 2;
        public override string GetDescription(Item item, bool includeCountPrefix)
        {
            if (item.FixedArtifact != null && item.IsFlavourAware())
            {
                return base.GetDescription(item, includeCountPrefix);
            }
            string flavour = item.IdentStoreb ? "" : $"{item.SaveGame.SingletonRepository.RingFlavours[item.ItemSubCategory].Name} ";
            if (!item.IsFlavourAware())
            {
                flavour = "Plain Gold ";
            }
            string ofName = item.IsFlavourAware() ? $" of {item.Factory.FriendlyName}" : "";
            string name = $"{flavour}{Pluralize("Ring", item.Count)}{ofName}";
            return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
        }
        public override Item CreateItem(SaveGame saveGame) => new PowerRingItem(saveGame);
    }
}
