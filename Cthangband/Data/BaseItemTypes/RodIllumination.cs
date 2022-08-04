using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class RodIllumination : RodItemCategory
    {
        public override char Character => '-';
        public override Colour Colour => Colour.Background;
        public override string Name => "Rod:Illumination";

        public override int Chance1 => 1;
        public override int Cost => 1000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Illumination";
        public override int Level => 20;
        public override int Locale1 => 20;
        public override int SubCategory => 4;
        public override int Weight => 15;
    }
}
