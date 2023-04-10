namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PotionCureSeriousWounds : PotionItemClass
    {
        private PotionCureSeriousWounds(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '!';
        public override string Name => "Cure Serious Wounds";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 40;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Cure Serious Wounds";
        public override int Level => 3;
        public override int[] Locale => new int[] { 3, 0, 0, 0 };
        public override int Pval => 100;
        public override int? SubCategory => (int)PotionType.CureSerious;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            bool identified = false;

            // Cure serious wounds heals you 4d8 health, cures blindness and confusion, and
            // reduces bleeding
            if (saveGame.Player.RestoreHealth(Program.Rng.DiceRoll(4, 8)))
            {
                identified = true;
            }
            if (saveGame.Player.TimedBlindness.ResetTimer())
            {
                identified = true;
            }
            if (saveGame.Player.TimedConfusion.ResetTimer())
            {
                identified = true;
            }
            if (saveGame.Player.TimedBleeding.SetTimer((saveGame.Player.TimedBleeding.TurnsRemaining / 2) - 50))
            {
                identified = true;
            }
            return identified;
        }

        public override bool Smash(SaveGame saveGame, int who, int y, int x)
        {
            saveGame.Project(who, 2, y, x, Program.Rng.DiceRoll(4, 3), new OldHealProjectile(saveGame), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
            return false;
        }
        public override Item CreateItem() => new CureSeriousWoundsPotionItem(SaveGame);
    }
}
