using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class StaffProbing : StaffItemCategory
    {
        public override char Character => '_';
        public override string Name => "Probing";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 2000;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "Probing";
        public override int Level => 30;
        public override int[] Locale => new int[] { 30, 0, 0, 0 };
        public override int? SubCategory => 23;
        public override int Weight => 50;
    }
}