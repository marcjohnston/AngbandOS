using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RingDisenchantmentResistance : RingItemClass
    {
        private RingDisenchantmentResistance(SaveGame saveGame) { } // This object is a singleton.

        public override char Character => '=';
        public override string Name => "Disenchantment Resistance";

        public override int[] Chance => new int[] { 10, 0, 0, 0 };
        public override int Cost => 15000;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Disenchantment Resistance";
        public override int Level => 90;
        public override int[] Locale => new int[] { 90, 0, 0, 0 };
        public override bool ResDisen => true;
        public override int? SubCategory => 45;
        public override int Weight => 2;
    }
}
