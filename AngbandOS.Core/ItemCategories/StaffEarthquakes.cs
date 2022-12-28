using AngbandOS.Core.EventArgs;
using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class StaffEarthquakes : StaffItemClass
    {
        public StaffEarthquakes(SaveGame saveGame) : base(saveGame) { }

        public override char Character => '_';
        public override string Name => "Earthquakes";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 350;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "Earthquakes";
        public override int Level => 40;
        public override int[] Locale => new int[] { 40, 0, 0, 0 };
        public override int? SubCategory => 28;
        public override int Weight => 50;
        public override void UseStaff(UseStaffEvent eventArgs)
        {
            eventArgs.SaveGame.Earthquake(eventArgs.SaveGame.Player.MapY, eventArgs.SaveGame.Player.MapX, 10);
            eventArgs.Identified = true;
        }
    }
}
