using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class HardArmorAugmentedChainMail : HardArmorItemClass
    {
        public override char Character => '[';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Augmented Chain Mail";

        public override int Ac => 16;
        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 900;
        public override int Dd => 1;
        public override int Ds => 4;
        public override string FriendlyName => "Augmented Chain Mail~";
        public override int Level => 30;
        public override int[] Locale => new int[] { 30, 0, 0, 0 };
        public override int? SubCategory => 6;
        public override int ToH => -2;
        public override int Weight => 270;
    }
}
