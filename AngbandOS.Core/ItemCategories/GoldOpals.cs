namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class GoldOpals : GoldItemClass
    {
        private GoldOpals(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '$';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "opals";

        public override int Cost => 18;
        public override string FriendlyName => "opals";
        public override int Level => 1;
        public override Item CreateItem(SaveGame saveGame) => new OpalsGoldItem(saveGame);
    }
}
