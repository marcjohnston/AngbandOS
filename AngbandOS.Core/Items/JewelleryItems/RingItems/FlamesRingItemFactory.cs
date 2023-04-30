namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class FlamesRingItemFactory : RingItemFactory
    {
        private FlamesRingItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override string? DescribeActivationEffect => "ball of fire and resist fire";
        public override char Character => '=';
        public override string Name => "Flames";

        public override bool Activate => true;
        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 3000;
        public override string FriendlyName => "Flames";
        public override bool IgnoreFire => true;
        public override int Level => 50;
        public override int[] Locale => new int[] { 50, 0, 0, 0 };
        public override bool ResFire => true;
        public override int? SubCategory => 18;
        public override int ToA => 15;
        public override int Weight => 2;
        public override Item CreateItem() => new FlamesRingItem(SaveGame);
    }
}
