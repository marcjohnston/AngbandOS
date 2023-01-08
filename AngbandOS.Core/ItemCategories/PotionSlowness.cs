namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PotionSlowness : PotionItemClass
    {
        private PotionSlowness(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '!';
        public override string Name => "Slowness";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Slowness";
        public override int Level => 1;
        public override int[] Locale => new int[] { 1, 0, 0, 0 };
        public override int Pval => 50;
        public override int? SubCategory => (int)PotionType.Slowness;
        public override int Weight => 4;

        public override bool Quaff(SaveGame saveGame)
        {
            // Slowness slows you down.
            return saveGame.Player.TimedSlow.SetTimer(saveGame.Player.TimedSlow.TimeRemaining + Program.Rng.DieRoll(25) + 15);
        }

        public override bool Smash(SaveGame saveGame, int who, int y, int x)
        {
            saveGame.Project(who, 2, y, x, 5, new ProjectOldSlow(saveGame), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
            return true;
        }
    }
}
