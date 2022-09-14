using AngbandOS.Core.Interface;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class SkeletonBrokenBone : SkeletonItemCategory
    {
        public override char Character => '~';
        public override Colour Colour => Colour.Beige;
        public override string Name => "Skeleton:Broken Bone";

        public override int Chance1 => 1;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "& Broken Bone~";
        public override int SubCategory => 2;
        public override int Weight => 2;
    }
}
