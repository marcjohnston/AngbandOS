namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ChaosBookTheBookofAzathoth : ChaosBookItemClass
    {
        private ChaosBookTheBookofAzathoth(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '?';
        public override Colour Colour => Colour.Red;
        public override string Name => "[The Book of Azathoth]";

        public override int[] Chance => new int[] { 3, 0, 0, 0 };
        public override int Cost => 100000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "[The Book of Azathoth]";
        public override int Level => 100;
        public override int[] Locale => new int[] { 100, 0, 0, 0 };
        public override int? SubCategory => 3;
        public override int Weight => 30;
        public override bool KindIsGood => true;
        public override Item CreateItem(SaveGame saveGame) => new AzathothChaosBookItem(saveGame);
    }
}
