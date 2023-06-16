namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class LeatherGlovesArmorItemFactory : GlovesArmorItemFactory
    {
        private LeatherGlovesArmorItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => ']';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Set of Leather Gloves";

        public override int Ac => 1;
        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 3;
        public override string FriendlyName => "& Set~ of Leather Gloves";
        public override int Level => 1;
        public override int[] Locale => new int[] { 1, 0, 0, 0 };
        public override int Weight => 5;
        public override Item CreateItem() => new LeatherGlovesArmourItem(SaveGame);
    }
}
