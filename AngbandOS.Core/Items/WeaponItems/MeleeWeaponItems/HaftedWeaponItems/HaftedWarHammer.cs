namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class HaftedWarHammer : HaftedItemClass
    {
        private HaftedWarHammer(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '\\';
        public override Colour Colour => Colour.Black;
        public override string Name => "War Hammer";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 225;
        public override int Dd => 3;
        public override int Ds => 3;
        public override string FriendlyName => "& War Hammer~";
        public override int Level => 5;
        public override int[] Locale => new int[] { 5, 0, 0, 0 };
        public override bool ShowMods => true;
        public override int? SubCategory => 8;
        public override int Weight => 120;
        public override Item CreateItem() => new WarHammerHaftedWeaponItem(SaveGame);
    }
}
