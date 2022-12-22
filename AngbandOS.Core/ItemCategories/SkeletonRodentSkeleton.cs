using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class SkeletonRodentSkeleton : SkeletonItemClass
    {
        private SkeletonRodentSkeleton(SaveGame saveGame) { } // This object is a singleton.

        public override char Character => '~';
        public override Colour Colour => Colour.Beige;
        public override string Name => "Rodent Skeleton";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "& Rodent Skeleton~";
        public override int Level => 1;
        public override int[] Locale => new int[] { 1, 0, 0, 0 };
        public override int? SubCategory => 3;
        public override int Weight => 10;
    }
}
