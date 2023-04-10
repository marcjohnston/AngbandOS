namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class HaftedTwoHandedFlail : HaftedItemClass
    {
        private HaftedTwoHandedFlail(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '\\';
        public override Colour Colour => Colour.Yellow;
        public override string Name => "Two-Handed Flail";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 590;
        public override int Dd => 3;
        public override int Ds => 6;
        public override string FriendlyName => "& Two-Handed Flail~";
        public override int Level => 45;
        public override int[] Locale => new int[] { 45, 0, 0, 0 };
        public override bool ShowMods => true;
        public override int? SubCategory => 18;
        public override int Weight => 280;
        public override Item CreateItem() => new TwoHandedFlailHaftedWeaponItem(SaveGame);
    }
}
