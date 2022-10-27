using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class StaffPower : StaffItemCategory
    {
        public override char Character => '_';
        public override string Name => "Power";

        public override int Chance1 => 2;
        public override int Cost => 4000;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "Power";
        public override int Level => 70;
        public override int Locale1 => 70;
        public override int? SubCategory => 25;
        public override int Weight => 50;
    }
}
