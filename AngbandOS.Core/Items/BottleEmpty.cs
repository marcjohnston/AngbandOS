using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class BottleEmpty : BottleItemClass
    {
        public override char Character => '!';
        public override string Name => "Empty Bottle";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 1;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "& Empty Bottle~";
        public override int? SubCategory => 1;
        public override int Weight => 2;
    }
}
