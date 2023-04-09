namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PolearmSpear : PolearmItemClass
    {
        private PolearmSpear(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '/';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Spear";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 36;
        public override int Dd => 1;
        public override int Ds => 6;
        public override string FriendlyName => "& Spear~";
        public override int Level => 5;
        public override int[] Locale => new int[] { 5, 0, 0, 0 };
        public override int? SubCategory => 2;
        public override int Weight => 50;
        public override Item CreateItem(SaveGame saveGame) => new SpearPolearmWeaponItem(saveGame);
    }
}
