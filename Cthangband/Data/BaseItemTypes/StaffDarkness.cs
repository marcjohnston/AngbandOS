using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class StaffDarkness : StaffItemCategory
    {
        public override char Character => '_';
        public override Colour Colour => Colour.Background;
        public override string Name => "Staff:Darkness";

        public override int Chance1 => 1;
        public override int Chance2 => 1;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "Darkness";
        public override int Level => 5;
        public override int Locale1 => 5;
        public override int Locale2 => 50;
        public override int Weight => 50;
    }
}
