namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class StaffSummoning : StaffItemClass
    {
        private StaffSummoning(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '_';
        public override string Name => "Summoning";

        public override int[] Chance => new int[] { 1, 1, 0, 0 };
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "Summoning";
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 50, 0, 0 };
        public override int? SubCategory => 3;
        public override int Weight => 50;
        public override void UseStaff(UseStaffEvent eventArgs)
        {
            for (int k = 0; k < Program.Rng.DieRoll(4); k++)
            {
                if (eventArgs.SaveGame.Level.SummonSpecific(eventArgs.SaveGame.Player.MapY, eventArgs.SaveGame.Player.MapX, eventArgs.SaveGame.Difficulty, null))
                {
                    eventArgs.Identified = true;
                }
            }
        }
        public override Item CreateItem() => new SummoningStaffItem(SaveGame);
    }
}
