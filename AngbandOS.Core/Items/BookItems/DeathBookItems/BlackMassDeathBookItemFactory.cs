namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class BlackMassDeathBookItemFactory : DeathBookItemFactory
    {
        private BlackMassDeathBookItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '?';
        public override Colour Colour => Colour.Grey;
        public override string Name => "[Black Mass]";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 1000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "[Black Mass]";
        public override int Level => 20;
        public override int[] Locale => new int[] { 20, 0, 0, 0 };
        public override int? SubCategory => 1;
        public override int Weight => 30;
        public override bool KindIsGood => false;
        public override Item CreateItem() => new BlackMassDeathBookItem(SaveGame);
    }
}
