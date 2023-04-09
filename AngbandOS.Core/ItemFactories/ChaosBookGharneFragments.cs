namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ChaosBookGharneFragments : ChaosBookItemClass
    {
        private ChaosBookGharneFragments(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '?';
        public override Colour Colour => Colour.Red;
        public override string Name => "[G'harne Fragments]";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 25000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "[G'harne Fragments]";
        public override int Level => 50;
        public override int[] Locale => new int[] { 50, 0, 0, 0 };
        public override int? SubCategory => 2;
        public override int Weight => 30;
        public override bool KindIsGood => true;
        public override Item CreateItem(SaveGame saveGame) => new GharneFragmentsChaosBookItem(saveGame);
    }
}
