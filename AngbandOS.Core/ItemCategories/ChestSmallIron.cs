using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ChestSmallIron : ChestItemClass
    {
        public override char Character => '~';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Small iron chest";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 100;
        public override int Dd => 2;
        public override int Ds => 4;
        public override string FriendlyName => "& Small iron chest~";
        public override int Level => 25;
        public override int[] Locale => new int[] { 25, 0, 0, 0 };
        public override int? SubCategory => 2;
        public override int Weight => 300;
        public override bool IsSmall => true;
        public override int NumberOfItemsContained => 4;
    }
}
