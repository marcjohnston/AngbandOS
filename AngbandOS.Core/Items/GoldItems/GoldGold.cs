namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class GoldGold : GoldItemClass
    {
        private GoldGold(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '$';
        public override Colour Colour => Colour.Gold;
        public override string Name => "gold";

        public override int Cost => 12;
        public override string FriendlyName => "gold";
        public override int Level => 1;
        public override Item CreateItem() => new GoldGoldItem(SaveGame);
    }
}