namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ShieldLargeLeatherShield : ShieldItemClass
    {
        private ShieldLargeLeatherShield(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => ')';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Large Leather Shield";

        public override int Ac => 4;
        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 120;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "& Large Leather Shield~";
        public override int Level => 15;
        public override int[] Locale => new int[] { 15, 0, 0, 0 };
        public override int? SubCategory => 4;
        public override int Weight => 100;
    }
}
