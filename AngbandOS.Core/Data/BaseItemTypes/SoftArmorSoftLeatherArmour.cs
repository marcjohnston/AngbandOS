using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class SoftArmorSoftLeatherArmour : SoftArmorItemCategory
    {
        public override char Character => '(';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "SoftArmor:Soft Leather Armour";

        public override int Ac => 4;
        public override int Chance1 => 1;
        public override int Cost => 18;
        public override string FriendlyName => "Soft Leather Armour~";
        public override int Level => 3;
        public override int Locale1 => 3;
        public override int SubCategory => 4;
        public override int Weight => 80;
    }
}
