using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class SkeletonElfSkeleton : SkeletonItemCategory
    {
        public override char Character => '~';
        public override Colour Colour => Colour.Beige;
        public override string Name => "Skeleton:Elf Skeleton";

        public override int Chance1 => 1;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "& Elf Skeleton~";
        public override int Level => 5;
        public override int Locale1 => 5;
        public override int SubCategory => 6;
        public override int Weight => 40;
    }
}
