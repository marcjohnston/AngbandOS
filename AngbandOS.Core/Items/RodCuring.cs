using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RodCuring : RodItemCategory
    {
        public override char Character => '-';
        public override string Name => "Curing";

        public override int[] Chance => new int[] { 8, 0, 0, 0 };
        public override int Cost => 15000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Curing";
        public override int Level => 65;
        public override int[] Locale => new int[] { 65, 0, 0, 0 };
        public override int? SubCategory => 8;
        public override int Weight => 15;
    }
}
