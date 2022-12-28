using AngbandOS.Core.EventArgs;
using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class StaffPower : StaffItemClass
    {
        private StaffPower(SaveGame saveGame) { } // This object is a singleton.

        public override char Character => '_';
        public override string Name => "Power";

        public override int[] Chance => new int[] { 2, 0, 0, 0 };
        public override int Cost => 4000;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "Power";
        public override int Level => 70;
        public override int[] Locale => new int[] { 70, 0, 0, 0 };
        public override int? SubCategory => 25;
        public override int Weight => 50;
        public override void UseStaff(UseStaffEvent eventArgs)
        {
            if (eventArgs.SaveGame.DispelMonsters(120))
            {
                eventArgs.Identified = true;
            }
        }
    }
}
