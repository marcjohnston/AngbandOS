using AngbandOS.Core.Interface;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class SoftArmorLeatherScaleMail : SoftArmorItemCategory
    {
        public override char Character => '(';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "SoftArmor:Leather Scale Mail";

        public override int Ac => 11;
        public override int Chance1 => 1;
        public override int Cost => 450;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Leather Scale Mail~";
        public override int Level => 15;
        public override int Locale1 => 15;
        public override int SubCategory => 11;
        public override int ToH => -1;
        public override int Weight => 140;
    }
}
