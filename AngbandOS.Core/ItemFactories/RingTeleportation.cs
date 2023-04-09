namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RingTeleportation : RingItemClass
    {
        private RingTeleportation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '=';
        public override string Name => "Teleportation";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 250;
        public override string FriendlyName => "Teleportation";
        public override int Level => 5;
        public override int[] Locale => new int[] { 5, 0, 0, 0 };
        public override int? SubCategory => 4;
        public override int Weight => 2;
        public override Item CreateItem(SaveGame saveGame) => new TeleportationRingItem(saveGame);
    }
}
