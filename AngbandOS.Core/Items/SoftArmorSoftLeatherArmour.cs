using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class SoftArmorSoftLeatherArmour : SoftArmorItemCategory
    {
        public override char Character => '(';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Soft Leather Armour";

        public override int Ac => 4;
        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 18;
        public override string FriendlyName => "Soft Leather Armour~";
        public override int Level => 3;
        public override int[] Locale => new int[] { 3, 0, 0, 0 };
        public override int? SubCategory => 4;
        public override int Weight => 80;
    }
}