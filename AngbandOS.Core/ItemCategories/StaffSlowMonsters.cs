using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class StaffSlowMonsters : StaffItemClass
    {
        public override char Character => '_';
        public override string Name => "Slow Monsters";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 800;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "Slow Monsters";
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 0, 0, 0 };
        public override int? SubCategory => 21;
        public override int Weight => 50;
    }
}
