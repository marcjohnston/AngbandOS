namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class GoldGarnets1 : GoldItemClass
    {
        private GoldGarnets1(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '$';
        public override Colour Colour => Colour.Red;
        public override string Name => "garnets*";

        public override int Cost => 10;
        public override string FriendlyName => "garnets";
        public override int Level => 1;
        public override Item CreateItem() => new Garnets1GoldItem(SaveGame);
    }
}
