namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class BrillianceAmuletJeweleryItemFactory : AmuletJeweleryItemFactory
    {
        private BrillianceAmuletJeweleryItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '"';
        public override string Name => "Brilliance";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 500;
        public override string FriendlyName => "Brilliance";
        public override bool HideType => true;
        public override bool Int => true;
        public override int Level => 20;
        public override int[] Locale => new int[] { 20, 0, 0, 0 };
        public override int Weight => 3;
        public override bool Wis => true;
        public override Item CreateItem() => new BrillianceAmuletJeweleryItem(SaveGame);
    }
}
