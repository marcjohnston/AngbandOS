namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class NecklaceAmuletJeweleryItemFactory : AmuletJeweleryItemFactory
    {
        private NecklaceAmuletJeweleryItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '"';
        public override string Name => "Dwarves";

        public override int Cost => 75000;
        public override string FriendlyName => "& Necklace~"; // TODO: This appears to cause a defect in identification
        public override bool InstaArt => true;
        public override int Level => 70;
        public override int Weight => 3;
        public override Item CreateItem() => new NecklaceAmuletJeweleryItem(SaveGame);
    }
}
