namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class LeadCrownArmorItemFactory : CrownArmorItemFactory
    {
        private LeadCrownArmorItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => ']';
        public override Colour Colour => Colour.Black;
        public override string Name => "Lead Crown";

        public override int Cost => 1000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "& Lead Crown~"; // TODO: This appears to cause a defect in identification
        public override bool InstaArt => true;
        public override int Level => 44;
        public override int? SubCategory => 50;
        public override int Weight => 20;
        public override Item CreateItem() => new LeadCrownArmorItem(SaveGame);
    }
}
