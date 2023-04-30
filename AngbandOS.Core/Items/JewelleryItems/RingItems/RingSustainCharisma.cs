namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RingSustainCharisma : RingItemFactory
    {
        private RingSustainCharisma(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '=';
        public override string Name => "Sustain Charisma";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 500;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Sustain Charisma";
        public override int Level => 30;
        public override int[] Locale => new int[] { 30, 0, 0, 0 };
        public override int? SubCategory => 15;
        public override bool SustCha => true;
        public override int Weight => 2;
        public override Item CreateItem() => new SustainCharismaRingItem(SaveGame);
    }
}
