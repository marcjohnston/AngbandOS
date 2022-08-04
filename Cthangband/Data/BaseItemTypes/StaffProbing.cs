using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class StaffProbing : StaffItemCategory
    {
        public override char Character => '_';
        public override Colour Colour => Colour.Background;
        public override string Name => "Staff:Probing";

        public override int Chance1 => 1;
        public override int Cost => 2000;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "Probing";
        public override int Level => 30;
        public override int Locale1 => 30;
        public override int SubCategory => 23;
        public override int Weight => 50;
    }
}
