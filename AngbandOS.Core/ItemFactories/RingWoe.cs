namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RingWoe : RingItemClass
    {
        private RingWoe(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '=';
        public override string Name => "Woe";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override string FriendlyName => "Woe";
        public override int Level => 50;
        public override int[] Locale => new int[] { 50, 0, 0, 0 };
        public override int Pval => -5;
        public override int Weight => 2;
        public override int? SubCategory => 0;
        public override Item CreateItem(SaveGame saveGame) => new WoeRingItem(saveGame);
    }
}
