using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RodTeleportOther : RodItemClass
    {
        public RodTeleportOther(SaveGame saveGame) : base(saveGame) { }

        public override bool RequiresAiming => true;
        public override char Character => '-';
        public override string Name => "Teleport Other";

        public override int[] Chance => new int[] { 2, 0, 0, 0 };
        public override int Cost => 1400;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Teleport Other";
        public override int Level => 45;
        public override int[] Locale => new int[] { 45, 0, 0, 0 };
        public override int? SubCategory => 13;
        public override int Weight => 15;
    }
}
