using AngbandOS.Core.EventArgs;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class StaffStarlight : StaffItemClass
    {
        private StaffStarlight(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '_';
        public override string Name => "Starlight";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 800;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "Starlight";
        public override int Level => 20;
        public override int[] Locale => new int[] { 20, 0, 0, 0 };
        public override int? SubCategory => 7;
        public override int Weight => 50;

        public override void UseStaff(UseStaffEvent eventArgs)
        {
            if (eventArgs.SaveGame.Player.TimedBlindness == 0)
            {
                eventArgs.SaveGame.MsgPrint("The end of the staff glows brightly...");
            }
            for (int k = 0; k < 8; k++)
            {
                eventArgs.SaveGame.LightLine(eventArgs.SaveGame.Level.OrderedDirection[k]);
            }
            eventArgs.Identified = true;
        }
    }
}
