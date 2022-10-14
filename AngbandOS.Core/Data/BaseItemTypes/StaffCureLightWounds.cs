using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class StaffCureLightWounds : StaffItemCategory
    {
        public override char Character => '_';
        public override string Name => "Staff:Cure Light Wounds";

        public override int Chance1 => 1;
        public override int Cost => 350;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "Cure Light Wounds";
        public override int Level => 5;
        public override int Locale1 => 5;
        public override int? SubCategory => 16;
        public override int Weight => 50;
    }
}
