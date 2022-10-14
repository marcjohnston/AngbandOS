using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class StaffSpeed : StaffItemCategory
    {
        public override char Character => '_';
        public override string Name => "Staff:Speed";

        public override int Chance1 => 1;
        public override int Cost => 1000;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "Speed";
        public override int Level => 40;
        public override int Locale1 => 40;
        public override int? SubCategory => 22;
        public override int Weight => 50;
    }
}
