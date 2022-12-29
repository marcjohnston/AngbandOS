namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class SkeletonDwarfSkeleton : SkeletonItemClass
    {
        private SkeletonDwarfSkeleton(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '~';
        public override Colour Colour => Colour.Beige;
        public override string Name => "Dwarf Skeleton";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "& Dwarf Skeleton~";
        public override int Level => 5;
        public override int[] Locale => new int[] { 5, 0, 0, 0 };
        public override int? SubCategory => 7;
        public override int Weight => 50;
    }
}
