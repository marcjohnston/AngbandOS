namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RingSpeed : RingItemFactory
    {
        private RingSpeed(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '=';
        public override string Name => "Speed";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 100000;
        public override string FriendlyName => "Speed";
        public override bool HideType => true;
        public override int Level => 80;
        public override int[] Locale => new int[] { 80, 0, 0, 0 };
        public override bool Speed => true;
        public override int? SubCategory => 31;
        public override int Weight => 2;

        public override bool KindIsGood => true;
        public override Item CreateItem() => new SpeedRingItem(SaveGame);
    }
}
