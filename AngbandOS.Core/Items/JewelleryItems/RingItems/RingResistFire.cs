namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RingResistFire : RingItemFactory
    {
        private RingResistFire(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '=';
        public override string Name => "Resist Fire";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 250;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Resist Fire";
        public override bool IgnoreFire => true;
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 0, 0, 0 };
        public override bool ResFire => true;
        public override int? SubCategory => 8;
        public override int Weight => 2;
        public override Item CreateItem() => new ResistFireRingItem(SaveGame);
    }
}
