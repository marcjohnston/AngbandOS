namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class StaffTeleportation : StaffItemClass
    {
        private StaffTeleportation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '_';
        public override string Name => "Teleportation";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 2000;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "Teleportation";
        public override int Level => 20;
        public override int[] Locale => new int[] { 20, 0, 0, 0 };
        public override int? SubCategory => 4;
        public override int Weight => 50;
        public override void UseStaff(UseStaffEvent eventArgs)
        {
            eventArgs.SaveGame.TeleportPlayer(100);
            eventArgs.Identified = true;
        }
        public override Item CreateItem() => new TeleportationStaffItem(SaveGame);
    }
}