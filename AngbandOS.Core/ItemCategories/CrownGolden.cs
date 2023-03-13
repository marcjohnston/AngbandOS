namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class CrownGolden : CrownItemClass
    {
        private CrownGolden(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => ']';
        public override Colour Colour => Colour.Gold;
        public override string Name => "Golden Crown";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 1000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "& Golden Crown~";
        public override bool IgnoreAcid => true;
        public override int Level => 45;
        public override int[] Locale => new int[] { 45, 0, 0, 0 };
        public override int? SubCategory => 11;
        public override int Weight => 30;
        public override Item CreateItem(SaveGame saveGame) => new GoldenCrownArmorItem(saveGame);
    }
}
