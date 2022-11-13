using AngbandOS.Enumerations;
using AngbandOS.Projection;
using System;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PotionCureLightWounds : PotionItemClass
    {
        public override char Character => '!';
        public override string Name => "Cure Light Wounds";

        public override int[] Chance => new int[] { 1, 1, 1, 0 };
        public override int Cost => 15;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Cure Light Wounds";
        public override int[] Locale => new int[] { 0, 1, 3, 0 };
        public override int Pval => 50;
        public override int? SubCategory => (int)PotionType.CureLight;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            bool identified = false;
            // Cure light wounds heals you 2d8 health and reduces bleeding
            if (saveGame.Player.RestoreHealth(Program.Rng.DiceRoll(2, 8)))
            {
                identified = true;
            }
            if (saveGame.Player.SetTimedBleeding(saveGame.Player.TimedBleeding - 10))
            {
                identified = true;
            }
            return identified;
        }

        public override bool Smash(SaveGame saveGame, int who, int y, int x)
        {
            saveGame.Project(who, 2, y, x, Program.Rng.DiceRoll(2, 3), new ProjectOldHeal(saveGame), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
            return false;
        }
    }
}
