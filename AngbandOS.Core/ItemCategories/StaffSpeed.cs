using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class StaffSpeed : StaffItemClass
    {
        private StaffSpeed(SaveGame saveGame) { } // This object is a singleton.

        public override char Character => '_';
        public override string Name => "Speed";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 1000;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "Speed";
        public override int Level => 40;
        public override int[] Locale => new int[] { 40, 0, 0, 0 };
        public override int? SubCategory => 22;
        public override int Weight => 50;
    }
}
