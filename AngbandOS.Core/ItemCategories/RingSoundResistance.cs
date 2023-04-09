namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RingSoundResistance : RingItemClass
    {
        private RingSoundResistance(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '=';
        public override string Name => "Sound Resistance";

        public override int[] Chance => new int[] { 2, 0, 0, 0 };
        public override int Cost => 3000;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Sound Resistance";
        public override int Level => 26;
        public override int[] Locale => new int[] { 26, 0, 0, 0 };
        public override bool ResSound => true;
        public override int? SubCategory => 42;
        public override int Weight => 2;
        public override Item CreateItem(SaveGame saveGame) => new SoundResistanceRingItem(saveGame);
    }
}
