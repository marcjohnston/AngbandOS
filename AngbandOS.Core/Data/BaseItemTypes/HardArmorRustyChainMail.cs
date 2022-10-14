using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class HardArmorRustyChainMail : HardArmorItemCategory
    {
        public override char Character => '[';
        public override Colour Colour => Colour.Red;
        public override string Name => "HardArmor:Rusty Chain Mail";

        public override int Ac => 14;
        public override int Chance1 => 1;
        public override int Cost => 550;
        public override int Dd => 1;
        public override int Ds => 4;
        public override string FriendlyName => "Rusty Chain Mail~";
        public override int Level => 25;
        public override int Locale1 => 25;
        public override int? SubCategory => 1;
        public override int ToA => -8;
        public override int ToH => -5;
        public override int Weight => 200;
    }
}
