namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class SwordCutlass : SwordItemClass
    {
        private SwordCutlass(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '|';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "Cutlass";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 85;
        public override int Dd => 1;
        public override int Ds => 7;
        public override string FriendlyName => "& Cutlass~";
        public override int Level => 5;
        public override int[] Locale => new int[] { 5, 0, 0, 0 };
        public override bool ShowMods => true;
        public override int? SubCategory => 12;
        public override int Weight => 110;
    }
}
