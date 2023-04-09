namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class DiggingGnomishShovel : DiggingItemClass
    {
        private DiggingGnomishShovel(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '\\';
        public override Colour Colour => Colour.BrightGreen;
        public override string Name => "Gnomish Shovel";

        public override int[] Chance => new int[] { 4, 0, 0, 0 };
        public override int Cost => 100;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "& Gnomish Shovel~";
        public override int Level => 20;
        public override int[] Locale => new int[] { 20, 0, 0, 0 };
        public override int Pval => 2;
        public override int Weight => 60;
        public override Item CreateItem(SaveGame saveGame) => new GnomishShovelDiggingWeaponItem(saveGame);
    }
}
