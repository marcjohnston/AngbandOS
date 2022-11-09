using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class StaffEarthquakes : StaffItemCategory
    {
        public override char Character => '_';
        public override string Name => "Earthquakes";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 350;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "Earthquakes";
        public override int Level => 40;
        public override int[] Locale => new int[] { 40, 0, 0, 0 };
        public override int? SubCategory => 28;
        public override int Weight => 50;
    }
}
