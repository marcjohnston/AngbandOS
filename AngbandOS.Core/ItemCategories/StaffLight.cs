using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class StaffLight : StaffItemClass
    {
        private StaffLight(SaveGame saveGame) { } // This object is a singleton.

        public override char Character => '_';
        public override string Name => "Light";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 250;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "Light";
        public override int Level => 5;
        public override int[] Locale => new int[] { 5, 0, 0, 0 };
        public override int? SubCategory => 8;
        public override int Weight => 50;
    }
}
