namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class BlindnessPotionItemFactory : PotionItemFactory
    {
        private BlindnessPotionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '!';
        public override string Name => "Blindness";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Blindness";
        public override int? SubCategory => (int)PotionType.Blindness;
        public override int Weight => 4;

        public override bool Quaff(SaveGame saveGame)
        {
            // Blindness makes you blind
            if (!saveGame.Player.HasBlindnessResistance)
                return saveGame.Player.TimedBlindness.AddTimer(Program.Rng.RandomLessThan(100) + 100);
            return false;
        }

        public override bool Smash(SaveGame saveGame, int who, int y, int x)
        {
            saveGame.Project(who, 2, y, x, 0, saveGame.SingletonRepository.Projectiles.Get<DarkProjectile>(), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
            return true;
        }
        public override Item CreateItem() => new BlindnessPotionItem(SaveGame);
    }
}
