using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class SkeletonElfSkeleton : SkeletonItemCategory
    {
        public override char Character => '~';
        public override Colour Colour => Colour.Beige;
        public override string Name => "Elf Skeleton";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "& Elf Skeleton~";
        public override int Level => 5;
        public override int[] Locale => new int[] { 5, 0, 0, 0 };
        public override int? SubCategory => 6;
        public override int Weight => 40;
    }
}