namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class StaffDetectEvil : StaffItemClass
    {
        private StaffDetectEvil(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '_';
        public override string Name => "Detect Evil";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 350;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "Detect Evil";
        public override int Level => 20;
        public override int[] Locale => new int[] { 20, 0, 0, 0 };
        public override int? SubCategory => 15;
        public override int Weight => 50;

        public override void UseStaff(UseStaffEvent eventArgs)
        {
            if (eventArgs.SaveGame.DetectMonstersEvil())
            {
                eventArgs.Identified = true;
            }
        }
        public override Item CreateItem() => new DetectEvilStaffItem(SaveGame);
    }
}