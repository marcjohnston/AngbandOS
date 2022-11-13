using AngbandOS.Core.Interface;
using System;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class SkeletonBrokenSkull : SkeletonItemClass
    {
        public override char Character => '~';
        public override Colour Colour => Colour.Beige;
        public override string Name => "Broken Skull";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "& Broken Skull~";
        public override int? SubCategory => 1;
        public override int Weight => 1;
    }
}
