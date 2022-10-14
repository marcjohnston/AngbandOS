using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class HardArmorFullPlateArmour : HardArmorItemCategory
    {
        public override char Character => '[';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "Full Plate Armour";

        public override int Ac => 25;
        public override int Chance1 => 1;
        public override int Cost => 1350;
        public override int Dd => 2;
        public override int Ds => 4;
        public override string FriendlyName => "Full Plate Armour~";
        public override int Level => 45;
        public override int Locale1 => 45;
        public override int? SubCategory => 15;
        public override int ToH => -3;
        public override int Weight => 380;
    }
}
