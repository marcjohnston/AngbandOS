using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class StaffTrapLocation : StaffItemCategory
    {
        public override char Character => '_';
        public override string Name => "Trap Location";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 350;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "Trap Location";
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 0, 0, 0 };
        public override int? SubCategory => 12;
        public override int Weight => 50;
    }
}
