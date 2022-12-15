using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RodFrostBolts : RodItemClass
    {
        public override bool RequiresAiming => true;
        public override char Character => '-';
        public override string Name => "Frost Bolts";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 2500;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Frost Bolts";
        public override int Level => 25;
        public override int[] Locale => new int[] { 25, 0, 0, 0 };
        public override int? SubCategory => 23;
        public override int Weight => 15;
    }
}
