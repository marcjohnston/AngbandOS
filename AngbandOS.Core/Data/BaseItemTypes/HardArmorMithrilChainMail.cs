using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class HardArmorMithrilChainMail : HardArmorItemCategory
    {
        public override char Character => '[';
        public override Colour Colour => Colour.BrightBlue;
        public override string Name => "HardArmor:Mithril Chain Mail";

        public override int Ac => 28;
        public override int Chance1 => 4;
        public override int Cost => 7000;
        public override int Dd => 1;
        public override int Ds => 4;
        public override string FriendlyName => "Mithril Chain Mail~";
        public override bool IgnoreAcid => true;
        public override int Level => 55;
        public override int Locale1 => 55;
        public override int SubCategory => 20;
        public override int ToH => -1;
        public override int Weight => 150;
    }
}
