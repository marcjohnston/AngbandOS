namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class GoldCopper2 : GoldItemClass
    {
        private GoldCopper2(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '$';
        public override Colour Colour => Colour.Copper;
        public override string Name => "copper**";

        public override int Cost => 5;
        public override string FriendlyName => "copper";
        public override int Level => 1;
        public override Item CreateItem() => new Copper2GoldItem(SaveGame);
    }
}
