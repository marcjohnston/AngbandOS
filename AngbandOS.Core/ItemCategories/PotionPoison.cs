namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PotionPoison : PotionItemClass
    {
        private PotionPoison(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '!';
        public override string Name => "Poison";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Poison";
        public override int Level => 3;
        public override int[] Locale => new int[] { 3, 0, 0, 0 };
        public override int? SubCategory => (int)PotionType.Poison;
        public override int Weight => 4;

        public override bool Quaff(SaveGame saveGame)
        {
            // Poison simply poisons you
            if (!(saveGame.Player.HasPoisonResistance || saveGame.Player.TimedPoisonResistance.TimeRemaining != 0))
            {
                // Hagarg Ryonis can protect you against poison
                if (Program.Rng.DieRoll(10) <= saveGame.Player.Religion.GetNamedDeity(Pantheon.GodName.Hagarg_Ryonis).AdjustedFavour)
                {
                    saveGame.MsgPrint("Hagarg Ryonis's favour protects you!");
                }
                else if (saveGame.Player.TimedPoison.SetTimer(saveGame.Player.TimedPoison.TimeRemaining + Program.Rng.RandomLessThan(15) + 10))
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
