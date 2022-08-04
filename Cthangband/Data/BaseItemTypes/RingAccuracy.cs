using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class RingAccuracy : RingItemCategory
    {
        public override char Character => '=';
        public override Colour Colour => Colour.Background;
        public override string Name => "Ring:Accuracy";

        public override int Chance1 => 1;
        public override int Cost => 500;
        public override string FriendlyName => "Accuracy";
        public override int Level => 20;
        public override int Locale1 => 20;
        public override int SubCategory => 28;
        public override int Weight => 2;
    }
}
