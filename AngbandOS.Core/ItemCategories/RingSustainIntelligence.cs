using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RingSustainIntelligence : RingItemClass
    {
        public override char Character => '=';
        public override string Name => "Sustain Intelligence";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 600;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Sustain Intelligence";
        public override int Level => 30;
        public override int[] Locale => new int[] { 30, 0, 0, 0 };
        public override int? SubCategory => 11;
        public override bool SustInt => true;
        public override int Weight => 2;
    }
}
