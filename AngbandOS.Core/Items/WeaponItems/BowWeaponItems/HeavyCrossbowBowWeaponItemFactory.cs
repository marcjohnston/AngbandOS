namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class HeavyCrossbowBowWeaponItemFactory : BowWeaponItemFactory
    {
        private HeavyCrossbowBowWeaponItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '}';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Heavy Crossbow";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 300;
        public override string FriendlyName => "& Heavy Crossbow~";
        public override int Level => 30;
        public override int[] Locale => new int[] { 30, 0, 0, 0 };
        public override bool ShowMods => true;
        public override int Weight => 200;
        public override int MissileDamageMultiplier => 4;
        public override ItemTypeEnum AmmunitionItemCategory => ItemTypeEnum.Bolt;
        public override Item CreateItem() => new HeavyCrossbowBowWeaponItem(SaveGame);
    }
}