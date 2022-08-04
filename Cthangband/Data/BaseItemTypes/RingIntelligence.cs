using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class RingIntelligence : RingItemCategory
    {
        public override char Character => '=';
        public override Colour Colour => Colour.Background;
        public override string Name => "Ring:Intelligence";

        public override int Chance1 => 1;
        public override int Cost => 500;
        public override string FriendlyName => "Intelligence";
        public override bool HideType => true;
        public override bool Int => true;
        public override int Level => 30;
        public override int Locale1 => 30;
        public override int SubCategory => 25;
        public override int Weight => 2;
    }
}
