using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class HardArmorAugmentedChainMail : HardArmorItemCategory
    {
        public override char Character => '[';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Augmented Chain Mail";

        public override int Ac => 16;
        public override int Chance1 => 1;
        public override int Cost => 900;
        public override int Dd => 1;
        public override int Ds => 4;
        public override string FriendlyName => "Augmented Chain Mail~";
        public override int Level => 30;
        public override int Locale1 => 30;
        public override int? SubCategory => 6;
        public override int ToH => -2;
        public override int Weight => 270;
    }
}
