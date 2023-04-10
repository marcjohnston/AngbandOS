namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PolearmPike : PolearmItemClass
    {
        private PolearmPike(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '/';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Pike";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 358;
        public override int Dd => 2;
        public override int Ds => 5;
        public override string FriendlyName => "& Pike~";
        public override int Level => 15;
        public override int[] Locale => new int[] { 15, 0, 0, 0 };
        public override bool ShowMods => true;
        public override int? SubCategory => 8;
        public override int Weight => 160;
        public override Item CreateItem() => new PikePolearmWeaponItem(SaveGame);
    }
}
