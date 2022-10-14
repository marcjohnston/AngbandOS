using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class SoftArmorRobe : SoftArmorItemCategory
    {
        public override char Character => '(';
        public override Colour Colour => Colour.Blue;
        public override string Name => "SoftArmor:Robe";

        public override int Ac => 2;
        public override int Chance1 => 1;
        public override int Chance2 => 1;
        public override int Cost => 4;
        public override string FriendlyName => "& Robe~";
        public override int Level => 1;
        public override int Locale1 => 1;
        public override int Locale2 => 50;
        public override int? SubCategory => 2;
        public override int Weight => 20;
    }
}
