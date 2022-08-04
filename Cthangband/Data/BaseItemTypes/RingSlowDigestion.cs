using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class RingSlowDigestion : RingItemCategory
    {
        public override char Character => '=';
        public override Colour Colour => Colour.Background;
        public override string Name => "Ring:Slow Digestion";

        public override int Chance1 => 1;
        public override int Cost => 250;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Slow Digestion";
        public override int Level => 5;
        public override int Locale1 => 5;
        public override bool SlowDigest => true;
        public override int SubCategory => 6;
        public override int Weight => 2;
    }
}
