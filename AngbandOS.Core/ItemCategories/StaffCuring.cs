using AngbandOS.Core.EventArgs;
using AngbandOS.Core.ItemClasses;

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
            if (eventArgs.SaveGame.Player.SetTimedBlindness(0))
            {
                eventArgs.Identified = true;
            }
            if (eventArgs.SaveGame.Player.SetTimedPoison(0))
            {
                eventArgs.Identified = true;
            }
            if (eventArgs.SaveGame.Player.SetTimedConfusion(0))
            {
                eventArgs.Identified = true;
            }
            if (eventArgs.SaveGame.Player.SetTimedStun(0))
            {
                eventArgs.Identified = true;
            }
            if (eventArgs.SaveGame.Player.SetTimedBleeding(0))
            {
                eventArgs.Identified = true;
            }
            if (eventArgs.SaveGame.Player.SetTimedHallucinations(0))
            {
                eventArgs.Identified = true;
            }
        }
    }
}
