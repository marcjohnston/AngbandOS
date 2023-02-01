namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class StaffSlowness : StaffItemClass
    {
        private StaffSlowness(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '_';
        public override string Name => "Slowness";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "Slowness";
        public override int Level => 40;
        public override int[] Locale => new int[] { 40, 0, 0, 0 };
        public override int? SubCategory => 1;
        public override int Weight => 50;

        public override void UseStaff(UseStaffEvent eventArgs)
        {
            if (eventArgs.SaveGame.Player.TimedSlow.AddTimer(Program.Rng.DieRoll(30) + 15))
            {
                eventArgs.Identified = true;
            }
        }
    }
}
