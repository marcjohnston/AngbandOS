namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PolearmGlaive : PolearmItemClass
    {
        private PolearmGlaive(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '/';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Glaive";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 363;
        public override int Dd => 2;
        public override int Ds => 6;
        public override string FriendlyName => "& Glaive~";
        public override int Level => 20;
        public override int[] Locale => new int[] { 20, 0, 0, 0 };
        public override bool ShowMods => true;
        public override int? SubCategory => 13;
        public override int Weight => 190;
    }
}
