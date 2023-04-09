namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class DiggingDwarvenShovel : DiggingItemClass
    {
        private DiggingDwarvenShovel(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '\\';
        public override Colour Colour => Colour.BrightBlue;
        public override string Name => "Dwarven Shovel";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 200;
        public override int Dd => 1;
        public override int Ds => 3;
        public override string FriendlyName => "& Dwarven Shovel~";
        public override int Level => 40;
        public override int[] Locale => new int[] { 40, 0, 0, 0 };
        public override int Pval => 3;
        public override bool ShowMods => true;
        public override bool Tunnel => true;
        public override int Weight => 120;
        public override Item CreateItem(SaveGame saveGame) => new DwarvenShovelDiggingWeaponItem(saveGame);
    }
}
