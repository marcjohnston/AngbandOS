using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class RingSustainIntelligence : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "Ring:Sustain Intelligence";

        public override int Chance1 => 1;
        public override int Cost => 600;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Sustain Intelligence";
        public override int Level => 30;
        public override int Locale1 => 30;
        public override int SubCategory => 11;
        public override bool SustInt => true;
        public override int Weight => 2;
    }
}
