namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class SpikeIronSpike : SpikeItemClass
    {
        private SpikeIronSpike(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '~';
        public override Colour Colour => Colour.Black;
        public override string Name => "Iron Spike";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 1;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "& Iron Spike~";
        public override int Level => 1;
        public override int[] Locale => new int[] { 1, 0, 0, 0 };
        public override int? SubCategory => 0;
        public override int Weight => 10;
        public override Item CreateItem() => new IronSpikeItem(SaveGame);
    }
}