namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class LightStarEssenceElendil : LightSourceItemClass
    {
        public override bool InstaArt => true;
        private LightStarEssenceElendil(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '*';
        public override Colour Colour => Colour.Yellow;
        public override string Name => "Star Essence Elendil";

        public override int Cost => 25000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "& Star Essence~"; // TODO: This appears to cause a defect in identification
        public override int Level => 30;
        public override int? SubCategory => 5;
        public override int Weight => 5;
        public override bool ProvidesSunlight => true;
        public override Item CreateItem(SaveGame saveGame) => new EssenceElendilLightItem(saveGame);
    }
}
