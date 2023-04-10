namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class SoftArmorRobe : SoftArmorItemClass
    {
        private SoftArmorRobe(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '(';
        public override Colour Colour => Colour.Blue;
        public override string Name => "Robe";

        public override int Ac => 2;
        public override int[] Chance => new int[] { 1, 1, 0, 0 };
        public override int Cost => 4;
        public override string FriendlyName => "& Robe~";
        public override int Level => 1;
        public override int[] Locale => new int[] { 1, 50, 0, 0 };
        public override int? SubCategory => 2;
        public override int Weight => 20;
        public override Item CreateItem(SaveGame saveGame) => new RobeSoftArmorItem(saveGame);
    }
}
