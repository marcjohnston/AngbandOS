using AngbandOS.Enumerations;
using AngbandOS.Projection;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionSlowness : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Slowness";

        public override int Chance1 => 1;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Slowness";
        public override int Level => 1;
        public override int Locale1 => 1;
        public override int Pval => 50;
        public override int? SubCategory => (int)PotionType.Slowness;
        public override int Weight => 4;

        public override bool Quaff(SaveGame saveGame)
        {
            // Slowness slows you down.
            return saveGame.Player.SetTimedSlow(saveGame.Player.TimedSlow + Program.Rng.DieRoll(25) + 15);
        }

        public override bool Smash(SaveGame saveGame, int who, int y, int x)
        {
            saveGame.Project(who, 2, y, x, 5, new ProjectOldSlow(saveGame), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
            return true;
        }
    }
}
