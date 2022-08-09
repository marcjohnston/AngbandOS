using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class RingSustainWisdom : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "Ring:Sustain Wisdom";

        public override int Chance1 => 1;
        public override int Cost => 600;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Sustain Wisdom";
        public override int Level => 30;
        public override int Locale1 => 30;
        public override int SubCategory => 12;
        public override bool SustWis => true;
        public override int Weight => 2;
    }
}
