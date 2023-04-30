namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RingSustainWisdom : RingItemFactory
    {
        private RingSustainWisdom(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '=';
        public override string Name => "Sustain Wisdom";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 600;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Sustain Wisdom";
        public override int Level => 30;
        public override int[] Locale => new int[] { 30, 0, 0, 0 };
        public override int? SubCategory => 12;
        public override bool SustWis => true;
        public override int Weight => 2;
        public override Item CreateItem() => new SustainWisdomRingItem(SaveGame);
    }
}
