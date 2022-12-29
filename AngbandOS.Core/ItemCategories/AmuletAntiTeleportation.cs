namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class AmuletAntiTeleportation : AmuletItemClass
    {
        private AmuletAntiTeleportation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '"';
        public override string Name => "Anti-Teleportation";

        public override int[] Chance => new int[] { 4, 0, 0, 0 };
        public override int Cost => 15000;
        public override string FriendlyName => "Anti-Teleportation";
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override int Level => 30;
        public override int[] Locale => new int[] { 30, 0, 0, 0 };
        public override bool NoTele => true;
        public override int Weight => 3;

        public override void ApplyMagic(Item item, int level, int power)
        {
            if (power < 0 || (power == 0 && Program.Rng.RandomLessThan(100) < 50))
            {
                item.IdentCursed = true;
            }
        }
    }
}
