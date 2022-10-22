using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class HardArmorMetalLamellarArmour : HardArmorItemCategory
    {
        public override char Character => '[';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "Metal Lamellar Armour";

        public override int Ac => 23;
        public override int Chance1 => 1;
        public override int Cost => 1250;
        public override int Dd => 1;
        public override int Ds => 6;
        public override string FriendlyName => "Metal Lamellar Armour~";
        public override int Level => 45;
        public override int Locale1 => 45;
        public override int? SubCategory => 13;
        public override int ToH => -3;
        public override int Weight => 340;
    }
}
