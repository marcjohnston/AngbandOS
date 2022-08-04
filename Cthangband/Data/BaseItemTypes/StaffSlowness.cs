using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class StaffSlowness : StaffItemCategory
    {
        public override char Character => '_';
        public override Colour Colour => Colour.Background;
        public override string Name => "Staff:Slowness";

        public override int Chance1 => 1;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "Slowness";
        public override int Level => 40;
        public override int Locale1 => 40;
        public override int SubCategory => 1;
        public override int Weight => 50;
    }
}
