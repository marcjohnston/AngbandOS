namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ConfusionResistanceRingItemFactory : RingItemFactory
    {
        private ConfusionResistanceRingItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '=';
        public override string Name => "Confusion Resistance";

        public override int[] Chance => new int[] { 2, 0, 0, 0 };
        public override int Cost => 3000;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Confusion Resistance";
        public override int Level => 22;
        public override int[] Locale => new int[] { 22, 0, 0, 0 };
        public override bool ResConf => true;
        public override int? SubCategory => 43;
        public override int Weight => 2;
        public override Item CreateItem() => new ConfusionResistanceRingItem(SaveGame);
    }
}