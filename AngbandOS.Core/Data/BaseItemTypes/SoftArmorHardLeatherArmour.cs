using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class SoftArmorHardLeatherArmour : SoftArmorItemCategory
    {
        public override char Character => '(';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "SoftArmor:Hard Leather Armour";

        public override int Ac => 6;
        public override int Chance1 => 1;
        public override int Cost => 150;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Hard Leather Armour~";
        public override int Level => 5;
        public override int Locale1 => 5;
        public override int SubCategory => 6;
        public override int ToH => -1;
        public override int Weight => 100;
    }
}
