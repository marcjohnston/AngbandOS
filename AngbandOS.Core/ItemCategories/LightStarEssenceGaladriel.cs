namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class LightStarEssenceGaladriel : LightSourceItemClass
    {
        private LightStarEssenceGaladriel(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '*';
        public override Colour Colour => Colour.Yellow;
        public override string Name => "Star Essence Galadriel";

        public override int Cost => 10000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "& Star Essence~"; // TODO: This appears to cause a defect in identification
        public override bool InstaArt => true;
        public override int Level => 1;
        public override int? SubCategory => 4;
        public override int Weight => 10;
        public override bool ProvidesSunlight => true;
        public override Item CreateItem(SaveGame saveGame) => new EssenceGaladrielLightItem(saveGame);
    }
}
