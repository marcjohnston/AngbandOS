using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class RodEnlightenment : RodItemCategory
    {
        public override char Character => '-';
        public override Colour Colour => Colour.Background;
        public override string Name => "Rod:Enlightenment";

        public override int Chance1 => 4;
        public override int Cost => 10000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Enlightenment";
        public override int Level => 65;
        public override int Locale1 => 65;
        public override int SubCategory => 5;
        public override int Weight => 15;
    }
}
