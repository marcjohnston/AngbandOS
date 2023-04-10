namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ScrollTeleportation : ScrollItemClass
    {
        private ScrollTeleportation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '?';
        public override string Name => "Teleportation";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 40;
        public override string FriendlyName => "Teleportation";
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 0, 0, 0 };
        public override int? SubCategory => 9;
        public override int Weight => 5;
        public override void Read(ReadScrollEvent eventArgs)
        {
            eventArgs.SaveGame.TeleportPlayer(100);
            eventArgs.Identified = true;
        }
        public override Item CreateItem() => new TeleportationScrollItem(SaveGame);
    }
}
