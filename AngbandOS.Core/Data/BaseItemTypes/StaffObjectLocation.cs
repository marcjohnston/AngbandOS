using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class StaffObjectLocation : StaffItemCategory
    {
        public override char Character => '_';
        public override string Name => "Staff:Object Location";

        public override int Chance1 => 1;
        public override int Cost => 200;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "Object Location";
        public override int Level => 5;
        public override int Locale1 => 5;
        public override int SubCategory => 11;
        public override int Weight => 50;
    }
}
