using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class StaffSummoning : StaffItemCategory
    {
        public override char Character => '_';
        public override Colour Colour => Colour.Background;
        public override string Name => "Staff:Summoning";

        public override int Chance1 => 1;
        public override int Chance2 => 1;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "Summoning";
        public override int Level => 10;
        public override int Locale1 => 10;
        public override int Locale2 => 50;
        public override int SubCategory => 3;
        public override int Weight => 50;
    }
}
