using AngbandOS.Interface;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class SkeletonRodentSkeleton : SkeletonItemCategory
    {
        public override char Character => '~';
        public override Colour Colour => Colour.Beige;
        public override string Name => "Skeleton:Rodent Skeleton";

        public override int Chance1 => 1;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "& Rodent Skeleton~";
        public override int Level => 1;
        public override int Locale1 => 1;
        public override int SubCategory => 3;
        public override int Weight => 10;
    }
}
