using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class RodRestoration : RodItemCategory
    {
        public override char Character => '-';
        public override Colour Colour => Colour.Background;
        public override string Name => "Rod:Restoration";

        public override int Chance1 => 16;
        public override int Cost => 25000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Restoration";
        public override int Level => 80;
        public override int Locale1 => 80;
        public override int SubCategory => 10;
        public override int Weight => 15;
    }
}
