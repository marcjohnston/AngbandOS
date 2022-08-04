using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class StaffTrapLocation : StaffItemCategory
    {
        public override char Character => '_';
        public override Colour Colour => Colour.Background;
        public override string Name => "Staff:Trap Location";

        public override int Chance1 => 1;
        public override int Cost => 350;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "Trap Location";
        public override int Level => 10;
        public override int Locale1 => 10;
        public override int SubCategory => 12;
        public override int Weight => 50;
    }
}
