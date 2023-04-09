namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class TarotBookEltdownShards : TarotBookItemClass
    {
        private TarotBookEltdownShards(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '?';
        public override Colour Colour => Colour.Pink;
        public override string Name => "[Eltdown Shards]";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 25000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "[Eltdown Shards]";
        public override int Level => 40;
        public override int[] Locale => new int[] { 40, 0, 0, 0 };
        public override int? SubCategory => 2;
        public override int Weight => 30;
        public override bool KindIsGood => true;
        public override Item CreateItem(SaveGame saveGame) => new EltdownShardsTarotBookItem(saveGame);
    }
}
