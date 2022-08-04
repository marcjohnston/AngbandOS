using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class ScrollMagicMapping : ScrollItemCategory
    {
        public override char Character => '?';
        public override Colour Colour => Colour.Background;
        public override string Name => "Scroll:Magic Mapping";

        public override int Chance1 => 1;
        public override int Cost => 40;
        public override string FriendlyName => "Magic Mapping";
        public override int Level => 5;
        public override int Locale1 => 5;
        public override int SubCategory => 25;
        public override int Weight => 5;
    }
}
