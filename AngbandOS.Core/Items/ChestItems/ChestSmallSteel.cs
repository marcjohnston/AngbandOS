namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ChestSmallSteel : ChestItemClass
    {
        private ChestSmallSteel(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '~';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Small steel chest";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 200;
        public override int Dd => 2;
        public override int Ds => 4;
        public override string FriendlyName => "& Small steel chest~";
        public override int Level => 45;
        public override int[] Locale => new int[] { 45, 0, 0, 0 };
        public override int? SubCategory => 3;
        public override int Weight => 500;
        public override bool IsSmall => true;
        public override int NumberOfItemsContained => 6;
        public override Item CreateItem(SaveGame saveGame) => new SmallSteelChestItem(saveGame);
    }
}
