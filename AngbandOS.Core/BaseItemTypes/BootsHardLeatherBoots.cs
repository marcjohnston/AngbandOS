using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class BootsHardLeatherBoots : BootsItemCategory
    {
        public override char Character => ']';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Pair of Hard Leather Boots";

        public override int Ac => 3;
        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 12;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "& Pair~ of Hard Leather Boots";
        public override int Level => 5;
        public override int[] Locale => new int[] { 5, 0, 0, 0 };
        public override int? SubCategory => 3;
        public override int Weight => 40;
    }
}
