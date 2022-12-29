namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class SwordDagger : SwordItemClass
    {
        private SwordDagger(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '|';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "Dagger";

        public override int[] Chance => new int[] { 1, 1, 1, 1 };
        public override int Cost => 10;
        public override int Dd => 1;
        public override int Ds => 4;
        public override string FriendlyName => "& Dagger~";
        public override int[] Locale => new int[] { 0, 5, 10, 20 };
        public override bool ShowMods => true;
        public override int? SubCategory => 4;
        public override int Weight => 12;
    }
}
