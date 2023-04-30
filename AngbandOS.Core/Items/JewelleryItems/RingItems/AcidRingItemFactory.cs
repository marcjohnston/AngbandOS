namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class AcidRingItemFactory : RingItemFactory
    {
        private AcidRingItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override string? DescribeActivationEffect => "ball of acid and resist acid";
        public override char Character => '=';
        public override string Name => "Acid";

        public override bool Activate => true;
        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 3000;
        public override string FriendlyName => "Acid";
        public override bool IgnoreAcid => true;
        public override int Level => 50;
        public override int[] Locale => new int[] { 50, 0, 0, 0 };
        public override bool ResAcid => true;
        public override int? SubCategory => 17;
        public override int ToA => 15;
        public override int Weight => 2;
        public override Item CreateItem() => new AcidRingItem(SaveGame);
    }
}
