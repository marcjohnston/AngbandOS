namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class SustainDexterityRingItemFactory : RingItemFactory
    {
        private SustainDexterityRingItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '=';
        public override string Name => "Sustain Dexterity";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 750;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Sustain Dexterity";
        public override int Level => 30;
        public override int[] Locale => new int[] { 30, 0, 0, 0 };
        public override int? SubCategory => 14;
        public override bool SustDex => true;
        public override int Weight => 2;
        public override Item CreateItem() => new SustainDexterityRingItem(SaveGame);
    }
}