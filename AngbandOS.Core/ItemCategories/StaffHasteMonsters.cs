using AngbandOS.Core.EventArgs;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class StaffHasteMonsters : StaffItemClass
    {
        private StaffHasteMonsters(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '_';
        public override string Name => "Haste Monsters";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "Haste Monsters";
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 0, 0, 0 };
        public override int? SubCategory => 2;
        public override int Weight => 50;

        public override void UseStaff(UseStaffEvent eventArgs)
        {
            if (eventArgs.SaveGame.HasteMonsters())
            {
                eventArgs.Identified = true;
            }
        }
    }
}
