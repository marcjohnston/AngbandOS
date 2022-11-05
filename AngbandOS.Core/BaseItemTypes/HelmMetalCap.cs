using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class HelmMetalCap : HelmItemCategory
    {
        public override char Character => ']';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Metal Cap";

        public override int Ac => 3;
        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 30;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "& Metal Cap~";
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 0, 0, 0 };
        public override int? SubCategory => 3;
        public override int Weight => 20;
    }
}
