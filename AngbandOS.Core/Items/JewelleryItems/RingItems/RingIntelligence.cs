namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RingIntelligence : RingItemClass
    {
        private RingIntelligence(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '=';
        public override string Name => "Intelligence";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 500;
        public override string FriendlyName => "Intelligence";
        public override bool HideType => true;
        public override bool Int => true;
        public override int Level => 30;
        public override int[] Locale => new int[] { 30, 0, 0, 0 };
        public override int? SubCategory => 25;
        public override int Weight => 2;
        public override Item CreateItem() => new IntelligenceRingItem(SaveGame);
    }
}
