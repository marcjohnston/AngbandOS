namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class GoldEmeralds : GoldItemClass
    {
        private GoldEmeralds(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '$';
        public override Colour Colour => Colour.Green;
        public override string Name => "emeralds";

        public override int Cost => 32;
        public override string FriendlyName => "emeralds";
        public override int Level => 1;
    }
}
