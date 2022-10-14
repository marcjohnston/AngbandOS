using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class SoftArmorSoftStuddedLeather : SoftArmorItemCategory
    {
        public override char Character => '(';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "SoftArmor:Soft Studded Leather";

        public override int Ac => 5;
        public override int Chance1 => 1;
        public override int Cost => 35;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Soft Studded Leather~";
        public override int Level => 3;
        public override int Locale1 => 3;
        public override int? SubCategory => 5;
        public override int Weight => 90;
    }
}
