namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class SkeletonBrokenSkull : SkeletonItemClass
    {
        private SkeletonBrokenSkull(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '~';
        public override Colour Colour => Colour.Beige;
        public override string Name => "Broken Skull";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "& Broken Skull~";
        public override int? SubCategory => 1;
        public override int Weight => 1;
        public override Item CreateItem(SaveGame saveGame) => new BrokenSkullSkeletonItem(saveGame);
    }
}
