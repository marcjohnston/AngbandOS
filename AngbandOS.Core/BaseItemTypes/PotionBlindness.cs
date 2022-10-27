using AngbandOS.Enumerations;
using AngbandOS.Projection;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionBlindness : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Blindness";

        public override int Chance1 => 1;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Blindness";
        public override int? SubCategory => (int)PotionType.Blindness;
        public override int Weight => 4;

        public override bool Quaff(SaveGame saveGame)
        {
            // Blindness makes you blind
            if (!saveGame.Player.HasBlindnessResistance)
                return saveGame.Player.SetTimedBlindness(saveGame.Player.TimedBlindness + Program.Rng.RandomLessThan(100) + 100);
            return false;
        }

        public override bool Smash(SaveGame saveGame, int who, int y, int x)
        {
            saveGame.Project(who, 2, y, x, 0, new ProjectDark(saveGame), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
            return true;
        }
    }
}
