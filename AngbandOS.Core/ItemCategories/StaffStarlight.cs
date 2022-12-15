using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class StaffStarlight : StaffItemClass
    {
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
    }
}
