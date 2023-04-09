namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RingBlindnessResistance : RingItemClass
    {
        private RingBlindnessResistance(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '=';
        public override string Name => "Blindness Resistance";

        public override int[] Chance => new int[] { 2, 0, 0, 0 };
        public override int Cost => 7500;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Blindness Resistance";
        public override int Level => 60;
        public override int[] Locale => new int[] { 60, 0, 0, 0 };
        public override bool ResBlind => true;
        public override int? SubCategory => 47;
        public override int Weight => 2;
        public override Item CreateItem(SaveGame saveGame) => new BlindnessResistanceRingItem(saveGame);
    }
}
