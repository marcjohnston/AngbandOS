using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class RingNenya : RingItemCategory
    {
        public override char Character => '=';
        public override Colour Colour => Colour.Background;
        public override string Name => "Ring:Ring***";

        public override int Cost => 200000;
        public override string FriendlyName => "& Ring~";
        public override bool InstaArt => true;
        public override int Level => 90;
        public override int SubCategory => 35;
        public override int Weight => 2;
    }
}
