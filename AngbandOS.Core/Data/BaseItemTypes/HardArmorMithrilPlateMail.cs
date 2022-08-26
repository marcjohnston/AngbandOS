using AngbandOS.Interface;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class HardArmorMithrilPlateMail : HardArmorItemCategory
    {
        public override char Character => '[';
        public override Colour Colour => Colour.BrightBlue;
        public override string Name => "HardArmor:Mithril Plate Mail";

        public override int Ac => 35;
        public override int Chance1 => 4;
        public override int Cost => 15000;
        public override int Dd => 2;
        public override int Ds => 4;
        public override string FriendlyName => "Mithril Plate Mail~";
        public override bool IgnoreAcid => true;
        public override int Level => 60;
        public override int Locale1 => 60;
        public override int SubCategory => 25;
        public override int ToH => -3;
        public override int Weight => 300;
    }
}
