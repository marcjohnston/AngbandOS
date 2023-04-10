namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class StaffCuring : StaffItemClass
    {
        private StaffCuring(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '_';
        public override string Name => "Curing";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 1000;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "Curing";
        public override int Level => 25;
        public override int[] Locale => new int[] { 25, 0, 0, 0 };
        public override int? SubCategory => 17;
        public override int Weight => 50;

        public override void UseStaff(UseStaffEvent eventArgs)
        {
            if (eventArgs.SaveGame.Player.TimedBlindness.ResetTimer())
            {
                eventArgs.Identified = true;
            }
            if (eventArgs.SaveGame.Player.TimedPoison.ResetTimer())
            {
                eventArgs.Identified = true;
            }
            if (eventArgs.SaveGame.Player.TimedConfusion.ResetTimer())
            {
                eventArgs.Identified = true;
            }
            if (eventArgs.SaveGame.Player.TimedStun.ResetTimer())
            {
                eventArgs.Identified = true;
            }
            if (eventArgs.SaveGame.Player.TimedBleeding.ResetTimer())
            {
                eventArgs.Identified = true;
            }
            if (eventArgs.SaveGame.Player.TimedHallucinations.ResetTimer())
            {
                eventArgs.Identified = true;
            }
        }
        public override Item CreateItem() => new CuringStaffItem(SaveGame);
    }
}
