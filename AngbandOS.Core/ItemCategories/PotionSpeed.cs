namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PotionSpeed : PotionItemClass
    {
        private PotionSpeed(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '!';
        public override string Name => "Speed";

        public override int[] Chance => new int[] { 1, 1, 1, 0 };
        public override int Cost => 75;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Speed";
        public override int Level => 1;
        public override int[] Locale => new int[] { 1, 40, 60, 0 };
        public override int? SubCategory => (int)PotionType.Speed;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // Speed temporarily hastes you.  But it is not additive.
            if (saveGame.Player.TimedHaste.TurnsRemaining == 0)
            {
                if (saveGame.Player.TimedHaste.SetTimer(Program.Rng.DieRoll(25) + 15))
                {
                    return true;
                }
            }
            else
            {
                saveGame.Player.TimedHaste.AddTimer(5);
            }
            return false;
        }

        public override bool Smash(SaveGame saveGame, int who, int y, int x)
        {
            saveGame.Project(who, 2, y, x, 0, new OldSpeedProjectile(saveGame), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
            return false;
        }
        public override Item CreateItem(SaveGame saveGame) => new SpeedPotionItem(saveGame);
    }
}
