namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class HardArmorPartialPlateArmour : HardArmorItemClass
    {
        private HardArmorPartialPlateArmour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '[';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "Partial Plate Armour";

        public override int Ac => 22;
        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 1200;
        public override int Dd => 1;
        public override int Ds => 6;
        public override string FriendlyName => "Partial Plate Armour~";
        public override int Level => 45;
        public override int[] Locale => new int[] { 45, 0, 0, 0 };
        public override int? SubCategory => 12;
        public override int ToH => -3;
        public override int Weight => 260;
    }
}
