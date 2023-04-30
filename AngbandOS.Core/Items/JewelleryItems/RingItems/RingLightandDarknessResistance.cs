namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RingLightAndDarknessResistanc : RingItemFactory
    {
        private RingLightAndDarknessResistanc(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '=';
        public override string Name => "Light and Darkness Resistance";

        public override int[] Chance => new int[] { 2, 0, 0, 0 };
        public override int Cost => 3000;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Light and Darkness Resistance";
        public override int Level => 30;
        public override int[] Locale => new int[] { 30, 0, 0, 0 };
        public override bool ResDark => true;
        public override bool ResLight => true;
        public override int? SubCategory => 39;
        public override int Weight => 2;
        public override Item CreateItem() => new LightAndDarknessResistancRingItem(SaveGame);
    }
}
