using AngbandOS.Enumerations;
using AngbandOS.Projection;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionSleep : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Sleep";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Sleep";
        public override int Pval => 100;
        public override int? SubCategory => (int)PotionType.Sleep;
        public override int Weight => 4;

        public override bool Quaff(SaveGame saveGame)
        {
            // Sleep paralyses you
            if (!saveGame.Player.HasFreeAction)
            {
                if (saveGame.Player.SetTimedParalysis(saveGame.Player.TimedParalysis + Program.Rng.RandomLessThan(4) + 4))
                {
                    return true;
                }
            }
            return false;
        }

        public override bool Smash(SaveGame saveGame, int who, int y, int x)
        {
            saveGame.Project(who, 2, y, x, 0, new ProjectOldSleep(saveGame), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
            return true;
        }
    }
}