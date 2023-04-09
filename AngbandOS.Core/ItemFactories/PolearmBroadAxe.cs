namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PolearmBroadAxe : PolearmItemClass
    {
        private PolearmBroadAxe(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '/';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Broad Axe";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 304;
        public override int Dd => 2;
        public override int Ds => 6;
        public override string FriendlyName => "& Broad Axe~";
        public override int Level => 15;
        public override int[] Locale => new int[] { 15, 0, 0, 0 };
        public override int? SubCategory => 11;
        public override int Weight => 160;
        public override Item CreateItem(SaveGame saveGame) => new BroadAxePolearmWeaponItem(saveGame);
    }
}
