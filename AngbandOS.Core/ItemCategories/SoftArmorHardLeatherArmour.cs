namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class SoftArmorHardLeatherArmour : SoftArmorItemClass
    {
        private SoftArmorHardLeatherArmour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '(';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Hard Leather Armour";

        public override int Ac => 6;
        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 150;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Hard Leather Armour~";
        public override int Level => 5;
        public override int[] Locale => new int[] { 5, 0, 0, 0 };
        public override int? SubCategory => 6;
        public override int ToH => -1;
        public override int Weight => 100;
    }
}
