using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ChestLargeIron : ChestItemCategory
    {
        public override char Character => '~';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Large iron chest";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 150;
        public override int Dd => 2;
        public override int Ds => 6;
        public override string FriendlyName => "& Large iron chest~";
        public override int Level => 35;
        public override int[] Locale => new int[] { 35, 0, 0, 0 };
        public override int? SubCategory => 6;
        public override int Weight => 1000;
        public override bool IsSmall => false;
        public override int NumberOfItemsContained => 4;
    }
}
