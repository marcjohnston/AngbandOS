using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class StaffHealing : StaffItemCategory
    {
        public override char Character => '_';
        public override string Name => "Healing";

        public override int Chance1 => 2;
        public override int Cost => 5000;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "Healing";
        public override int Level => 70;
        public override int Locale1 => 70;
        public override int? SubCategory => 18;
        public override int Weight => 50;
    }
}
