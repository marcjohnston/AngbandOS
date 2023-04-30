namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RingTulkas : RingItemFactory
    {
        private RingTulkas(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '=';
        public override string Name => "Tulkas";

        public override int Cost => 150000;
        public override string FriendlyName => "& Ring~"; // TODO: This appears to cause a defect in identification
        public override bool InstaArt => true;
        public override int Level => 90;
        public override int? SubCategory => 33;
        public override int Weight => 2;
        public override Item CreateItem() => new TulkasRingItem(SaveGame);
    }
}
