using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class StaffDispelEvil : StaffItemCategory
    {
        public override char Character => '_';
        public override string Name => "Staff:Dispel Evil";

        public override int Chance1 => 1;
        public override int Cost => 1200;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "Dispel Evil";
        public override int Level => 50;
        public override int Locale1 => 50;
        public override int? SubCategory => 24;
        public override int Weight => 50;
    }
}
