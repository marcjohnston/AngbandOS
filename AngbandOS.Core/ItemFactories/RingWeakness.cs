namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RingWeakness : RingItemClass
    {
        private RingWeakness(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '=';
        public override string Name => "Weakness";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override string FriendlyName => "Weakness";
        public override int Level => 5;
        public override int[] Locale => new int[] { 5, 0, 0, 0 };
        public override int Pval => -5;
        public override int? SubCategory => 2;
        public override int Weight => 2;
        public override Item CreateItem(SaveGame saveGame) => new WeaknessRingItem(saveGame);
    }
}
