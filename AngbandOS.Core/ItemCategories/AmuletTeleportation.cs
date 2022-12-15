using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class AmuletTeleportation : AmuletItemClass
    {
        public override char Character => '"';
        public override string Name => "Teleportation";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 250;
        public override bool Cursed => true;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Teleportation";
        public override int Level => 15;
        public override int[] Locale => new int[] { 15, 0, 0, 0 };
        public override bool Teleport => true;
        public override int Weight => 3;
    }
}
