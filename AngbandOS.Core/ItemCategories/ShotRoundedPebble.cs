namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ShotRoundedPebble : ShotItemClass
    {
        private ShotRoundedPebble(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '{';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Rounded Pebble";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 1;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "& Rounded Pebble~";
        public override bool ShowMods => true;
        public override int? SubCategory => 0;
        public override int Weight => 4;
    }
}
