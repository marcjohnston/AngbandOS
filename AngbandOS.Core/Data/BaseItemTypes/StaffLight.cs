using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class StaffLight : StaffItemCategory
    {
        public override char Character => '_';
        public override string Name => "Staff:Light";

        public override int Chance1 => 1;
        public override int Cost => 250;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "Light";
        public override int Level => 5;
        public override int Locale1 => 5;
        public override int SubCategory => 8;
        public override int Weight => 50;
    }
}
