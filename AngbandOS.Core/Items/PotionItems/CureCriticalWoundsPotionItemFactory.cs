using AngbandOS.Core.Items;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class CureCriticalWoundsPotionItemFactory : PotionItemFactory
    {
        private CureCriticalWoundsPotionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '!';
        public override string Name => "Cure Critical Wounds";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 100;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Cure Critical Wounds";
        public override int Level => 5;
        public override int[] Locale => new int[] { 5, 0, 0, 0 };
        public override int Pval => 100;
        public override int? SubCategory => (int)PotionType.CureCritical;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            bool identified = false;

            // Cure critical wounds heals you 6d8 health, and cures blindness, confusion, stun,
            // poison, and bleeding
            if (saveGame.Player.RestoreHealth(Program.Rng.DiceRoll(6, 8)))
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
            if (saveGame.Player.TimedPoison.ResetTimer())
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

            return identified;
        }

        public override bool Smash(SaveGame saveGame, int who, int y, int x)
        {
            saveGame.Project(who, 2, y, x, Program.Rng.DiceRoll(6, 3), saveGame.SingletonRepository.Projectiles.Get<OldHealProjectile>(), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
            return false;
        }
        public override Item CreateItem() => new CureCriticalWoundsPotionItem(SaveGame);
    }
}