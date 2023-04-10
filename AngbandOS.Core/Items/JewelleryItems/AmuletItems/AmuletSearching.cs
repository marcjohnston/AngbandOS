namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class AmuletSearching : AmuletItemClass
    {
        private AmuletSearching(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '"';
        public override string Name => "Searching";

        public override int[] Chance => new int[] { 4, 0, 0, 0 };
        public override int Cost => 600;
        public override string FriendlyName => "Searching";
        public override bool HideType => true;
        public override int Level => 30;
        public override int[] Locale => new int[] { 30, 0, 0, 0 };
        public override bool Search => true;
        public override int Weight => 3;
        public override Item CreateItem(SaveGame saveGame) => new SearchingAmuletItem(saveGame);
    }
}
