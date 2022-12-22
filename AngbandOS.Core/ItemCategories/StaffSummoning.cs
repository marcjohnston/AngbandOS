using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class StaffSummoning : StaffItemClass
    {
        private StaffSummoning(SaveGame saveGame) { } // This object is a singleton.

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
    }
}
