namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class StaffHealing : StaffItemClass
    {
        private StaffHealing(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '_';
        public override string Name => "Healing";

        public override int[] Chance => new int[] { 2, 0, 0, 0 };
        public override int Cost => 5000;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "Healing";
        public override int Level => 70;
        public override int[] Locale => new int[] { 70, 0, 0, 0 };
        public override int? SubCategory => 18;
        public override int Weight => 50;
        public override void UseStaff(UseStaffEvent eventArgs)
        {
            if (eventArgs.SaveGame.Player.RestoreHealth(300))
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
        }
    }
}
