namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class SwordShortSword : SwordItemClass
    {
        private SwordShortSword(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '|';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "Short Sword";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 90;
        public override int Dd => 1;
        public override int Ds => 7;
        public override string FriendlyName => "& Short Sword~";
        public override int Level => 5;
        public override int[] Locale => new int[] { 5, 0, 0, 0 };
        public override bool ShowMods => true;
        public override int? SubCategory => 10;
        public override int Weight => 80;
        public override Item CreateItem(SaveGame saveGame) => new ShortSwordWeaponItem(saveGame);
    }
}
