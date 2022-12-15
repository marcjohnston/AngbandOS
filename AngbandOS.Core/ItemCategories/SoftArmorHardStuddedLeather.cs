using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class SoftArmorHardStuddedLeather : SoftArmorItemClass
    {
        public override char Character => '(';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Hard Studded Leather";

        public override int Ac => 7;
        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 200;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "Hard Studded Leather~";
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 0, 0, 0 };
        public override int? SubCategory => 7;
        public override int ToH => -1;
        public override int Weight => 110;
    }
}
