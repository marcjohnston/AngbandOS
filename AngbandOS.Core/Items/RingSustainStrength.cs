using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RingSustainStrength : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "Sustain Strength";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 750;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Sustain Strength";
        public override int Level => 30;
        public override int[] Locale => new int[] { 30, 0, 0, 0 };
        public override int? SubCategory => 10;
        public override bool SustStr => true;
        public override int Weight => 2;
    }
}