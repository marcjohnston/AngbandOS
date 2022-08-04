using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class RodProbing : RodItemCategory
    {
        public override char Character => '-';
        public override Colour Colour => Colour.Background;
        public override string Name => "Rod:Probing";

        public override int Chance1 => 4;
        public override int Cost => 4000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Probing";
        public override int Level => 40;
        public override int Locale1 => 40;
        public override int SubCategory => 7;
        public override int Weight => 15;
    }
}
