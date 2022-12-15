using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class StaffHoliness : StaffItemClass
    {
        public override char Character => '_';
        public override string Name => "Holiness";

        public override int[] Chance => new int[] { 2, 0, 0, 0 };
        public override int Cost => 4500;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "Holiness";
        public override int Level => 70;
        public override int[] Locale => new int[] { 70, 0, 0, 0 };
        public override int? SubCategory => 26;
        public override int Weight => 50;
    }
}
