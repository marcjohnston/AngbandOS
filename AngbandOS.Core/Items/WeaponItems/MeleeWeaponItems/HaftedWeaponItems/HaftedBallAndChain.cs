namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class HaftedBallAndChain : HaftedItemClass
    {
        private HaftedBallAndChain(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '\\';
        public override Colour Colour => Colour.Black;
        public override string Name => "Ball-and-Chain";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 200;
        public override int Dd => 2;
        public override int Ds => 4;
        public override string FriendlyName => "& Ball-and-Chain~";
        public override int Level => 20;
        public override int[] Locale => new int[] { 20, 0, 0, 0 };
        public override bool ShowMods => true;
        public override int? SubCategory => 6;
        public override int Weight => 150;
        public override Item CreateItem() => new BallAndChainHaftedWeaponItem(SaveGame);
    }
}