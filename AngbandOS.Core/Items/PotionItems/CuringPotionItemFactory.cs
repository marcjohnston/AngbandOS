namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class CuringPotionItemFactory : PotionItemFactory
    {
        private CuringPotionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '!';
        public override string Name => "Curing";

        public override int[] Chance => new int[] { 1, 1, 0, 0 };
        public override int Cost => 250;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Curing";
        public override int Level => 18;
        public override int[] Locale => new int[] { 18, 40, 0, 0 };
        public override int Pval => 100;
        public override int? SubCategory => (int)PotionType.Curing;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            bool identified = false;
            // Curing heals you 50 health, and cures blindness, confusion, stun, poison,
            // bleeding, and hallucinations
            if (saveGame.Player.RestoreHealth(50))
            {
                identified = true;
            }
            if (saveGame.Player.TimedBlindness.ResetTimer())
            {
                identified = true;
            }
            if (saveGame.Player.TimedPoison.ResetTimer())
            {
                identified = true;
            }
            if (saveGame.Player.TimedConfusion.ResetTimer())
            {
                identified = true;
            }
            if (saveGame.Player.TimedStun.ResetTimer())
            {
                identified = true;
            }
            if (saveGame.Player.TimedBleeding.ResetTimer())
            {
                identified = true;
            }
            if (saveGame.Player.TimedHallucinations.ResetTimer())
            {
                identified = true;
            }
            return identified;
        }
        public override bool Smash(SaveGame saveGame, int who, int y, int x)
        {
            saveGame.Project(who, 2, y, x, Program.Rng.DiceRoll(6, 3), new OldHealProjectile(saveGame), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
            return false;
        }
        public override Item CreateItem() => new CuringPotionItem(SaveGame);
    }
}
