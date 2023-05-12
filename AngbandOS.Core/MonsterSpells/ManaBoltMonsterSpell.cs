namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class ManaBoltMonsterSpell : BoltProjectileMonsterSpell
    {
        public override bool CanBeReflected => true;
        public override bool IsAttack => true;
        protected override string ActionName => "casts a mana bolt";
        protected override int Damage(Monster monster)
        {
            int monsterLevel = monster.Race.Level >= 1 ? monster.Race.Level : 1;
            return Program.Rng.DieRoll(monsterLevel * 7 / 2) + 50;
        }
        protected override Projectile Projectile(SaveGame saveGame) => saveGame.SingletonRepository.Projectiles.Get<ManaProjectile>();
        public override SpellResistantDetection[] SmartLearn => new SpellResistantDetection[] { new ReflectSpellResistantDetection() };
    }
}
