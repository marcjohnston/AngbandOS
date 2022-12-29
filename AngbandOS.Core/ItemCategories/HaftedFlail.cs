namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class HaftedFlail : HaftedItemClass
    {
        private HaftedFlail(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '\\';
        public override Colour Colour => Colour.Black;
        public override string Name => "Flail";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 353;
        public override int Dd => 2;
        public override int Ds => 6;
        public override string FriendlyName => "& Flail~";
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 0, 0, 0 };
        public override bool ShowMods => true;
        public override int? SubCategory => 13;
        public override int Weight => 150;
    }
}
