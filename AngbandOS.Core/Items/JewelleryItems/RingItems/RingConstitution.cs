namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RingConstitution : RingItemFactory
    {
        private RingConstitution(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '=';
        public override string Name => "Constitution";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override bool Con => true;
        public override int Cost => 500;
        public override string FriendlyName => "Constitution";
        public override bool HideType => true;
        public override int Level => 30;
        public override int[] Locale => new int[] { 30, 0, 0, 0 };
        public override int? SubCategory => 27;
        public override int Weight => 2;
        public override Item CreateItem() => new ConstitutionRingItem(SaveGame);
    }
}
