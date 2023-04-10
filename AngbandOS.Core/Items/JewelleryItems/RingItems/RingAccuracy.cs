namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RingAccuracy : RingItemClass
    {
        private RingAccuracy(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '=';
        public override string Name => "Accuracy";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 500;
        public override string FriendlyName => "Accuracy";
        public override int Level => 20;
        public override int[] Locale => new int[] { 20, 0, 0, 0 };
        public override int? SubCategory => 28;
        public override int Weight => 2;
        public override Item CreateItem() => new AccuracyRingItem(SaveGame);
    }
}
