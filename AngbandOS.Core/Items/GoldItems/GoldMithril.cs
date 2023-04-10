namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class GoldMithril : GoldItemClass
    {
        private GoldMithril(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '$';
        public override Colour Colour => Colour.BrightBlue;
        public override string Name => "mithril";

        public override int Cost => 40;
        public override string FriendlyName => "mithril";
        public override int Level => 1;
        public override Item CreateItem() => new MithrilGoldItem(SaveGame);
    }
}
