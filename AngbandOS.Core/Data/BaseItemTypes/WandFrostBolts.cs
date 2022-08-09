using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class WandFrostBolts : WandItemCategory
    {
        public override char Character => '-';
        public override string Name => "Wand:Frost Bolts";

        public override int Chance1 => 1;
        public override int Cost => 800;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Frost Bolts";
        public override int Level => 20;
        public override int Locale1 => 20;
        public override int SubCategory => 19;
        public override int Weight => 10;
    }
}
