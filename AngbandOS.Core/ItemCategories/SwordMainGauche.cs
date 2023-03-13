namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class SwordMainGauche : SwordItemClass
    {
        private SwordMainGauche(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '|';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "Main Gauche";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 25;
        public override int Dd => 1;
        public override int Ds => 5;
        public override string FriendlyName => "& Main Gauche~";
        public override int Level => 3;
        public override int[] Locale => new int[] { 3, 0, 0, 0 };
        public override bool ShowMods => true;
        public override int? SubCategory => 5;
        public override int Weight => 30;
        public override Item CreateItem(SaveGame saveGame) => new MainGaucheSwordWeaponItem(saveGame);
    }
}
