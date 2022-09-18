using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RodLightningBolts : RodItemCategory
    {
        public override char Character => '-';
        public override string Name => "Rod:Lightning Bolts";

        public override int Chance1 => 1;
        public override int Cost => 2000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Lightning Bolts";
        public override int Level => 20;
        public override int Locale1 => 20;
        public override int SubCategory => 21;
        public override int Weight => 15;
    }
}
