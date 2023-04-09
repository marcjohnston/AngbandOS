namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class BootsSoftLeatherBoots : BootsItemClass
    {
        private BootsSoftLeatherBoots(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => ']';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Pair of Soft Leather Boots";

        public override int Ac => 2;
        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 7;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "& Pair~ of Soft Leather Boots";
        public override int Level => 3;
        public override int[] Locale => new int[] { 3, 0, 0, 0 };
        public override int? SubCategory => 2;
        public override int Weight => 20;
        public override Item CreateItem(SaveGame saveGame) => new SoftLeatherBootsItem(saveGame);
    }
}
