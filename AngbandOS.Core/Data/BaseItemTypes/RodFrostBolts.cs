using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RodFrostBolts : RodItemCategory
    {
        public override char Character => '-';
        public override string Name => "Rod:Frost Bolts";

        public override int Chance1 => 1;
        public override int Cost => 2500;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Frost Bolts";
        public override int Level => 25;
        public override int Locale1 => 25;
        public override int SubCategory => 23;
        public override int Weight => 15;
    }
}
