using AngbandOS.Core.ItemClasses;
using AngbandOS.Enumerations;
using AngbandOS.Projection;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PotionSpecialHealing : PotionItemClass
    {
        public PotionSpecialHealing(SaveGame saveGame) : base(saveGame) { }

        public override char Character => '!';
        public override string Name => "*Healing*";

        public override int[] Chance => new int[] { 4, 2, 1, 0 };
        public override int Cost => 1500;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "*Healing*";
        public override int Level => 40;
        public override int[] Locale => new int[] { 40, 60, 80, 0 };
        public override int? SubCategory => (int)PotionType.StarHealing;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            bool identified = false;

            // *Healing* heals you 1200 health, and cures blindness, confusion, stun, poison,
            // and bleeding
            if (saveGame.Player.RestoreHealth(1200))
            {
                identified = true;
            }
            if (saveGame.Player.SetTimedBlindness(0))
            {
                identified = true;
            }
            if (saveGame.Player.SetTimedConfusion(0))
            {
                identified = true;
            }
            if (saveGame.Player.SetTimedPoison(0))
            {
                identified = true;
            }
            if (saveGame.Player.SetTimedStun(0))
            {
                identified = true;
            }
            if (saveGame.Player.SetTimedBleeding(0))
            {
                identified = true;
            }

            return identified;
        }

        public override bool Smash(SaveGame saveGame, int who, int y, int x)
        {
            saveGame.Project(who, 1, y, x, Program.Rng.DiceRoll(50, 50), new ProjectOldHeal(saveGame), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
            return false;
        }
    }
}
