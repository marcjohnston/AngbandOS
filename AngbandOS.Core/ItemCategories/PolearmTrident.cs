namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PolearmTrident : PolearmItemClass
    {
        private PolearmTrident(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '/';
        public override Colour Colour => Colour.Yellow;
        public override string Name => "Trident";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 120;
        public override int Dd => 1;
        public override int Ds => 8;
        public override string FriendlyName => "& Trident~";
        public override int Level => 5;
        public override int[] Locale => new int[] { 5, 0, 0, 0 };
        public override bool ShowMods => true;
        public override int? SubCategory => 5;
        public override int Weight => 70;
        public override Item CreateItem(SaveGame saveGame) => new TridentPolearmWeaponItem(saveGame);
    }
}
