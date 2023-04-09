namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ChestRuined : ChestItemClass
    {
        private ChestRuined(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '~';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Ruined chest";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override string FriendlyName => "& Ruined chest~";
        public override int[] Locale => new int[] { 75, 0, 0, 0 };
        public override int? SubCategory => 0;
        public override int Weight => 250;
        public override bool IsSmall => true;
        public override int NumberOfItemsContained => 0;
        public override Item CreateItem(SaveGame saveGame) => new RuinedChestItem(saveGame);
    }
}
