namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class SwordTulwar : SwordItemClass
    {
        private SwordTulwar(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '|';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "Tulwar";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 200;
        public override int Dd => 2;
        public override int Ds => 4;
        public override string FriendlyName => "& Tulwar~";
        public override int Level => 5;
        public override int[] Locale => new int[] { 5, 0, 0, 0 };
        public override int? SubCategory => 15;
        public override int Weight => 100;
        public override Item CreateItem(SaveGame saveGame) => new TulwarSwordWeaponItem(saveGame);
    }
}
