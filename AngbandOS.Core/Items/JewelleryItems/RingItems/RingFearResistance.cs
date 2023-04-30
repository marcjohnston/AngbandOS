namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RingFearResistance : RingItemFactory
    {
        private RingFearResistance(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '=';
        public override string Name => "Fear Resistance";

        public override int[] Chance => new int[] { 2, 0, 0, 0 };
        public override int Cost => 300;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Fear Resistance";
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 0, 0, 0 };
        public override bool ResFear => true;
        public override int? SubCategory => 38;
        public override int Weight => 2;
        public override Item CreateItem() => new FearResistanceRingItem(SaveGame);
    }
}
