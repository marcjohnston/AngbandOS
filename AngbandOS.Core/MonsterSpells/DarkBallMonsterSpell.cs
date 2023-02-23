namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class DarkBallMonsterSpell : BallProjectileMonsterSpell
    {
        public override bool UsesDarkness => true;
        public override bool IsAttack => true;

        /// <summary>
        /// Returns a message that the monster mumbles powerfully.
        /// </summary>
        /// <param name="monsterName"></param>
        /// <returns></returns>
        public override string? VsPlayerBlindMessage => $"You hear someone mumble powerfully.";

        protected override string ActionName => "invokes a darkness storm";
        protected override Projectile Projectile(SaveGame saveGame) => new DarkProjectile(saveGame);
        protected override int Damage(Monster monster)
        {
            int monsterLevel = monster.Race.Level >= 1 ? monster.Race.Level : 1;
            return (monsterLevel * 5) + Program.Rng.DiceRoll(10, 10);
        }
        protected override int Radius => 4;
        public override SpellResistantDetection[] SmartLearn => new SpellResistantDetection[] { new DarkSpellResistantDetection() };
    }
}
