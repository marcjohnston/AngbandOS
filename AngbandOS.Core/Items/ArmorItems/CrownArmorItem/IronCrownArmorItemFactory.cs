namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class CrownIron : CrownArmorItemFactory
    {
        private CrownIron(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => ']';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Iron Crown";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 500;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "& Iron Crown~";
        public override int Level => 45;
        public override int[] Locale => new int[] { 45, 0, 0, 0 };
        public override int? SubCategory => 10;
        public override int Weight => 20;
        public override Item CreateItem() => new IronCrownArmorItem(SaveGame);
    }
}
