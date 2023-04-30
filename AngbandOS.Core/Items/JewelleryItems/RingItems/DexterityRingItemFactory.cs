namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class DexterityRingItemFactory : RingItemFactory
    {
        private DexterityRingItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '=';
        public override string Name => "Dexterity";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 500;
        public override bool Dex => true;
        public override string FriendlyName => "Dexterity";
        public override bool HideType => true;
        public override int Level => 30;
        public override int[] Locale => new int[] { 30, 0, 0, 0 };
        public override int? SubCategory => 26;
        public override int Weight => 2;
        public override Item CreateItem() => new DexterityRingItem(SaveGame);
    }
}
