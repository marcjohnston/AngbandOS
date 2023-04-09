namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class GoldCopper : GoldItemClass
    {
        private GoldCopper(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '$';
        public override Colour Colour => Colour.Copper;
        public override string Name => "copper";

        public override int Cost => 3;
        public override string FriendlyName => "copper";
        public override int Level => 1;
        public override Item CreateItem(SaveGame saveGame) => new CopperGoldItem(saveGame);
    }
}
