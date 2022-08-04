using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class StaffCuring : StaffItemCategory
    {
        public override char Character => '_';
        public override Colour Colour => Colour.Background;
        public override string Name => "Staff:Curing";

        public override int Chance1 => 1;
        public override int Cost => 1000;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "Curing";
        public override int Level => 25;
        public override int Locale1 => 25;
        public override int SubCategory => 17;
        public override int Weight => 50;
    }
}
