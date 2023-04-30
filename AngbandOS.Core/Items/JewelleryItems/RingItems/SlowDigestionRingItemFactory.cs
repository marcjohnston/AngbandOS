namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class SlowDigestionRingItemFactory : RingItemFactory
    {
        private SlowDigestionRingItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '=';
        public override string Name => "Slow Digestion";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 250;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Slow Digestion";
        public override int Level => 5;
        public override int[] Locale => new int[] { 5, 0, 0, 0 };
        public override bool SlowDigest => true;
        public override int? SubCategory => 6;
        public override int Weight => 2;
        public override Item CreateItem() => new SlowDigestionRingItem(SaveGame);
    }
}
