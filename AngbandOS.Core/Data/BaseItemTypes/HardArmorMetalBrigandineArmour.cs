using AngbandOS.Interface;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class HardArmorMetalBrigandineArmour : HardArmorItemCategory
    {
        public override char Character => '[';
        public override Colour Colour => Colour.Grey;
        public override string Name => "HardArmor:Metal Brigandine Armour";

        public override int Ac => 19;
        public override int Chance1 => 1;
        public override int Cost => 1100;
        public override int Dd => 1;
        public override int Ds => 4;
        public override string FriendlyName => "Metal Brigandine Armour~";
        public override int Level => 35;
        public override int Locale1 => 35;
        public override int SubCategory => 9;
        public override int ToH => -3;
        public override int Weight => 290;
    }
}
