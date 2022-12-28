using AngbandOS.Core.EventArgs;
using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class StaffDispelEvil : StaffItemClass
    {
        private StaffDispelEvil(SaveGame saveGame) { } // This object is a singleton.

        public override char Character => '_';
        public override string Name => "Dispel Evil";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 1200;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "Dispel Evil";
        public override int Level => 50;
        public override int[] Locale => new int[] { 50, 0, 0, 0 };
        public override int? SubCategory => 24;
        public override int Weight => 50;
        public override void UseStaff(UseStaffEvent eventArgs)
        {
            if (eventArgs.SaveGame.DispelEvil(60))
            {
                eventArgs.Identified = true;
            }
        }
    }
}
