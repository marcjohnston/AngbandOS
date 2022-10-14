using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class HardArmorDoubleChainMail : HardArmorItemCategory
    {
        public override char Character => '[';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Double Chain Mail";

        public override int Ac => 16;
        public override int Chance1 => 1;
        public override int Cost => 850;
        public override int Dd => 1;
        public override int Ds => 4;
        public override string FriendlyName => "Double Chain Mail~";
        public override int Level => 30;
        public override int Locale1 => 30;
        public override int? SubCategory => 7;
        public override int ToH => -2;
        public override int Weight => 250;
    }
}
