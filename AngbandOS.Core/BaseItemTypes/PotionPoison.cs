using AngbandOS.Enumerations;
using AngbandOS.Projection;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionPoison : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Poison";

        public override int Chance1 => 1;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Poison";
        public override int Level => 3;
        public override int Locale1 => 3;
        public override int? SubCategory => (int)PotionType.Poison;
        public override int Weight => 4;

        public override bool Quaff(SaveGame saveGame)
        {
            // Poison simply poisons you
            if (!(saveGame.Player.HasPoisonResistance || saveGame.Player.TimedPoisonResistance != 0))
            {
                // Hagarg Ryonis can protect you against poison
                if (Program.Rng.DieRoll(10) <= saveGame.Player.Religion.GetNamedDeity(Pantheon.GodName.Hagarg_Ryonis).AdjustedFavour)
                {
                    saveGame.MsgPrint("Hagarg Ryonis's favour protects you!");
                }
                else if (saveGame.Player.SetTimedPoison(saveGame.Player.TimedPoison + Program.Rng.RandomLessThan(15) + 10))
                {
                    return true;
                }
            }
            return false;
        }

        public override bool Smash(SaveGame saveGame, int who, int y, int x)
        {
            saveGame.Project(who, 2, y, x, 3, new ProjectPois(saveGame), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
            return true;
        }
    }
}
