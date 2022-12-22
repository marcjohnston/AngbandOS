using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class StaffDarkness : StaffItemClass
    {
        private StaffDarkness(SaveGame saveGame) { } // This object is a singleton.

        public override char Character => '_';
        public override string Name => "Darkness";

        public override int[] Chance => new int[] { 1, 1, 0, 0 };
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "Darkness";
        public override int Level => 5;
        public override int[] Locale => new int[] { 5, 50, 0, 0 };
        public override int? SubCategory => 0;
        public override int Weight => 50;
    }
}
