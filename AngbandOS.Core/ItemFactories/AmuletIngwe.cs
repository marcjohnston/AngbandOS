namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class AmuletIngwe : AmuletItemClass
    {
        public override bool InstaArt => true;
        private AmuletIngwe(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '"';
        public override string Name => "Ingwe";

        public override int Cost => 90000;
        public override string FriendlyName => "& Amulet~"; // TODO: This appears to cause a defect in identification
        public override int Level => 60;
        public override int Weight => 3;
        public override Item CreateItem(SaveGame saveGame) => new IngweAmuletItem(saveGame);
    }
}
