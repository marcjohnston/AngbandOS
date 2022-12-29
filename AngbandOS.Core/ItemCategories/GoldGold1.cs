namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class GoldGold1 : GoldItemClass
    {
        private GoldGold1(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '$';
        public override Colour Colour => Colour.Gold;
        public override string Name => "gold*";

        public override int Cost => 14;
        public override string FriendlyName => "gold";
        public override int Level => 1;
    }
}
