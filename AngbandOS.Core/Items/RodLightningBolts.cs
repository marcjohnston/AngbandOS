using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RodLightningBolts : RodItemCategory
    {
        public override char Character => '-';
        public override string Name => "Lightning Bolts";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 2000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Lightning Bolts";
        public override int Level => 20;
        public override int[] Locale => new int[] { 20, 0, 0, 0 };
        public override int? SubCategory => 21;
        public override int Weight => 15;
    }
}
