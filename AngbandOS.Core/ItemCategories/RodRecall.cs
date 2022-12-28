using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RodRecall : RodItemClass
    {
        public RodRecall(SaveGame saveGame) : base(saveGame) { }

        public override bool RequiresAiming => false;
        public override char Character => '-';
        public override string Name => "Recall";

        public override int[] Chance => new int[] { 4, 0, 0, 0 };
        public override int Cost => 4000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Recall";
        public override int Level => 30;
        public override int[] Locale => new int[] { 30, 0, 0, 0 };
        public override int? SubCategory => 3;
        public override int Weight => 15;
    }
}
