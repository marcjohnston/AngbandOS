using AngbandOS.Core.EventArgs;
using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class StaffHoliness : StaffItemClass
    {
        private StaffHoliness(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '_';
        public override string Name => "Holiness";

        public override int[] Chance => new int[] { 2, 0, 0, 0 };
        public override int Cost => 4500;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "Holiness";
        public override int Level => 70;
        public override int[] Locale => new int[] { 70, 0, 0, 0 };
        public override int? SubCategory => 26;
        public override int Weight => 50;
        public override void UseStaff(UseStaffEvent eventArgs)
        {
            if (eventArgs.SaveGame.DispelEvil(120))
            {
                eventArgs.Identified = true;
            }
            int k = 3 * eventArgs.SaveGame.Player.Level;
            if (eventArgs.SaveGame.Player.SetTimedProtectionFromEvil(eventArgs.SaveGame.Player.TimedProtectionFromEvil + Program.Rng.DieRoll(25) + k))
            {
                eventArgs.Identified = true;
            }
            if (eventArgs.SaveGame.Player.SetTimedPoison(0))
            {
                eventArgs.Identified = true;
            }
            if (eventArgs.SaveGame.Player.SetTimedFear(0))
            {
                eventArgs.Identified = true;
            }
            if (eventArgs.SaveGame.Player.RestoreHealth(50))
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
        }
    }
}
