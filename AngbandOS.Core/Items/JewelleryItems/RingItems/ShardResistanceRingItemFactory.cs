namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ShardResistanceRingItemFactory : RingItemFactory
    {
        private ShardResistanceRingItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '=';
        public override string Name => "Shard Resistance";

        public override int[] Chance => new int[] { 2, 0, 0, 0 };
        public override int Cost => 3000;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Shard Resistance";
        public override int Level => 25;
        public override int[] Locale => new int[] { 25, 0, 0, 0 };
        public override bool ResShards => true;
        public override int? SubCategory => 44;
        public override int Weight => 2;
        public override Item CreateItem() => new ShardResistanceRingItem(SaveGame);
    }
}
