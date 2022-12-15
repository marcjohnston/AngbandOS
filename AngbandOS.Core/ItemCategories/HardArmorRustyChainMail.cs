using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class HardArmorRustyChainMail : HardArmorItemClass
    {
        public override char Character => '[';
        public override Colour Colour => Colour.Red;
        public override string Name => "Rusty Chain Mail";

        public override int Ac => 14;
        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 550;
        public override int Dd => 1;
        public override int Ds => 4;
        public override string FriendlyName => "Rusty Chain Mail~";
        public override int Level => 25;
        public override int[] Locale => new int[] { 25, 0, 0, 0 };
        public override int? SubCategory => 1;
        public override int ToA => -8;
        public override int ToH => -5;
        public override int Weight => 200;
    }
}
