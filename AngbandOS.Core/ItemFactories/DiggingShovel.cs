namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class DiggingShovel : DiggingItemClass
    {
        private DiggingShovel(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '\\';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Shovel";

        public override int[] Chance => new int[] { 16, 0, 0, 0 };
        public override int Cost => 10;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "& Shovel~";
        public override int Level => 1;
        public override int[] Locale => new int[] { 5, 0, 0, 0 };
        public override int Pval => 1;
        public override int Weight => 60;
        public override Item CreateItem(SaveGame saveGame) => new ShovelDiggingWeaponItem(saveGame);
    }
}
