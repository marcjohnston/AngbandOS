namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class BootsMetalShodBoots : BootsItemClass
    {
        private BootsMetalShodBoots(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => ']';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Pair of Metal Shod Boots";

        public override int Ac => 6;
        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 50;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "& Pair~ of Metal Shod Boots";
        public override int Level => 20;
        public override int[] Locale => new int[] { 20, 0, 0, 0 };
        public override int? SubCategory => 6;
        public override int Weight => 80;
        public override Item CreateItem() => new MetalShodBootsItem(SaveGame);
    }
}