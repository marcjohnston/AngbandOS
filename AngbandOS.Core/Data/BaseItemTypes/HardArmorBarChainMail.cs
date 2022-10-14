using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class HardArmorBarChainMail : HardArmorItemCategory
    {
        public override char Character => '[';
        public override Colour Colour => Colour.Grey;
        public override string Name => "HardArmor:Bar Chain Mail";

        public override int Ac => 18;
        public override int Chance1 => 1;
        public override int Cost => 950;
        public override int Dd => 1;
        public override int Ds => 4;
        public override string FriendlyName => "Bar Chain Mail~";
        public override int Level => 35;
        public override int Locale1 => 35;
        public override int? SubCategory => 8;
        public override int ToH => -2;
        public override int Weight => 280;
    }
}
