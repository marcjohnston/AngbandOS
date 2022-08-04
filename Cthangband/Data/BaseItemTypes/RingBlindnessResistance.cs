using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class RingBlindnessResistance : RingItemCategory
    {
        public override char Character => '=';
        public override Colour Colour => Colour.Background;
        public override string Name => "Ring:Blindness Resistance";

        public override int Chance1 => 2;
        public override int Cost => 7500;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Blindness Resistance";
        public override int Level => 60;
        public override int Locale1 => 60;
        public override bool ResBlind => true;
        public override int SubCategory => 47;
        public override int Weight => 2;
    }
}
