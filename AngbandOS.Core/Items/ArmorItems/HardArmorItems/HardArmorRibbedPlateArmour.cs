namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class HardArmorRibbedPlateArmour : HardArmorItemClass
    {
        private HardArmorRibbedPlateArmour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '[';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "Ribbed Plate Armour";

        public override int Ac => 28;
        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 1500;
        public override int Dd => 2;
        public override int Ds => 4;
        public override string FriendlyName => "Ribbed Plate Armour~";
        public override int Level => 50;
        public override int[] Locale => new int[] { 50, 0, 0, 0 };
        public override int? SubCategory => 18;
        public override int ToH => -3;
        public override int Weight => 380;
        public override Item CreateItem() => new RibbedPlateArmourHardArmorItem(SaveGame);
    }
}