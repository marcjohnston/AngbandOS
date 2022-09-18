using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RingSustainStrength : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "Ring:Sustain Strength";

        public override int Chance1 => 1;
        public override int Cost => 750;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Sustain Strength";
        public override int Level => 30;
        public override int Locale1 => 30;
        public override int SubCategory => 10;
        public override bool SustStr => true;
        public override int Weight => 2;
    }
}
