namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RingNarya : RingItemClass
    {
        public override bool InstaArt => true;
        private RingNarya(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '=';
        public override string Name => "Narya";

        public override int Cost => 100000;
        public override string FriendlyName => "& Ring~"; // TODO: This appears to cause a defect in identification
        public override int Level => 80;
        public override int? SubCategory => 34;
        public override int Weight => 2;
        public override Item CreateItem(SaveGame saveGame) => new NaryaRingItem(saveGame);
    }
}
