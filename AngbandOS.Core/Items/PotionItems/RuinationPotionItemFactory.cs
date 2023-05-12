namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RuinationPotionItemFactory : PotionItemFactory
    {
        private RuinationPotionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '!';
        public override string Name => "Ruination";

        public override int[] Chance => new int[] { 8, 0, 0, 0 };
        public override int Dd => 20;
        public override int Ds => 20;
        public override string FriendlyName => "Ruination";
        public override int Level => 40;
        public override int[] Locale => new int[] { 40, 0, 0, 0 };
        public override int? SubCategory => (int)PotionType.Ruination;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // Ruination does 10d10 damage and reduces all your ability scores, bypassing
            // sustains and divine protection
            saveGame.MsgPrint("Your nerves and muscles feel weak and lifeless!");
            saveGame.Player.TakeHit(Program.Rng.DiceRoll(10, 10), "a potion of Ruination");
            saveGame.Player.DecreaseAbilityScore(Ability.Dexterity, 25, true);
            saveGame.Player.DecreaseAbilityScore(Ability.Wisdom, 25, true);
            saveGame.Player.DecreaseAbilityScore(Ability.Constitution, 25, true);
            saveGame.Player.DecreaseAbilityScore(Ability.Strength, 25, true);
            saveGame.Player.DecreaseAbilityScore(Ability.Charisma, 25, true);
            saveGame.Player.DecreaseAbilityScore(Ability.Intelligence, 25, true);
            return true;
        }

        public override bool Smash(SaveGame saveGame, int who, int y, int x)
        {
            saveGame.Project(who, 2, y, x, Program.Rng.DiceRoll(25, 25), saveGame.SingletonRepository.Projectiles.Get<ExplodeProjectile>(), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
            return true;
        }
        public override Item CreateItem() => new RuinationPotionItem(SaveGame);
    }
}
