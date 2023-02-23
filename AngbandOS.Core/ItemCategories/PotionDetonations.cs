namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PotionDetonations : PotionItemClass
    {
        private PotionDetonations(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '!';
        public override string Name => "Detonations";

        public override int[] Chance => new int[] { 8, 0, 0, 0 };
        public override int Cost => 10000;
        public override int Dd => 25;
        public override int Ds => 25;
        public override string FriendlyName => "Detonations";
        public override int Level => 60;
        public override int[] Locale => new int[] { 60, 0, 0, 0 };
        public override int? SubCategory => (int)PotionType.Detonations;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // Detonations does 50d20 damage, stuns you, and gives you a stupid amount of bleeding
            saveGame.MsgPrint("Massive explosions rupture your body!");
            saveGame.Player.TakeHit(Program.Rng.DiceRoll(50, 20), "a potion of Detonation");
            saveGame.Player.TimedStun.AddTimer(75);
            saveGame.Player.TimedBleeding.AddTimer(5000);
            return true;
        }

        public override bool Smash(SaveGame saveGame, int who, int y, int x)
        {
            saveGame.Project(who, 2, y, x, Program.Rng.DiceRoll(25, 25), new ExplodeProjectile(saveGame), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
            return true;
        }
    }
}
