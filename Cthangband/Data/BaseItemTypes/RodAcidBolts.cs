using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class RodAcidBolts : RodItemCategory
    {
        public override char Character => '-';
        public override Colour Colour => Colour.Background;
        public override string Name => "Rod:Acid Bolts";

        public override int Chance1 => 1;
        public override int Cost => 3500;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Acid Bolts";
        public override int Level => 40;
        public override int Locale1 => 40;
        public override int SubCategory => 20;
        public override int Weight => 15;
    }
}
