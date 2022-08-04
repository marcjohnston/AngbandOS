using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class SkeletonHumanSkeleton : SkeletonItemCategory
    {
        public override char Character => '~';
        public override Colour Colour => Colour.Beige;
        public override string Name => "Skeleton:Human Skeleton";

        public override int Chance1 => 1;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "& Human Skeleton~";
        public override int Level => 5;
        public override int Locale1 => 5;
        public override int SubCategory => 8;
        public override int Weight => 60;
    }
}
