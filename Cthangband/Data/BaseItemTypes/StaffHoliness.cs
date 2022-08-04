using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class StaffHoliness : StaffItemCategory
    {
        public override char Character => '_';
        public override Colour Colour => Colour.Background;
        public override string Name => "Staff:Holiness";

        public override int Chance1 => 2;
        public override int Cost => 4500;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "Holiness";
        public override int Level => 70;
        public override int Locale1 => 70;
        public override int SubCategory => 26;
        public override int Weight => 50;
    }
}
