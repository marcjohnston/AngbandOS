namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class AmuletTeleportation : AmuletItemClass
    {
        private AmuletTeleportation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '"';
        public override string Name => "Teleportation";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 250;
        public override string FriendlyName => "Teleportation";
        public override int Level => 15;
        public override int[] Locale => new int[] { 15, 0, 0, 0 };
        public override int Weight => 3;
        public override Item CreateItem(SaveGame saveGame) => new TeleportationAmuletItem(saveGame);
    }
}
