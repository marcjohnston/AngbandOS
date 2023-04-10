namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ArrowArrowAmmunitionItemFactory : ArrowAmmunitionItemFactory
    {
        private ArrowArrowAmmunitionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '{';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Arrow";

        public override int[] Chance => new int[] { 1, 1, 0, 0 };
        public override int Cost => 1;
        public override int Dd => 1;
        public override int Ds => 4;
        public override string FriendlyName => "& Arrow~";
        public override int Level => 3;
        public override int[] Locale => new int[] { 3, 15, 0, 0 };
        public override bool ShowMods => true;
        public override int? SubCategory => 1;
        public override int Weight => 2;
        public override Item CreateItem() => new ArrowArrowAmmunitionItem(SaveGame);
    }
}
