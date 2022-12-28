using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RodLight : RodItemClass
    {
        public RodLight(SaveGame saveGame) : base(saveGame) { }

        public override bool RequiresAiming => true;
        public override char Character => '-';
        public override string Name => "Light";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 500;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Light";
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 0, 0, 0 };
        public override int? SubCategory => 15;
        public override int Weight => 15;
    }
}
