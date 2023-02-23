namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class PoisonBoltMonsterSpell : BoltProjectileMonsterSpell
    {
        public override bool UsesPoison => true;
        public override bool CanBeReflected => true;
        public override bool IsAttack => true;
        protected override string ActionName => "casts a poison bolt";
        protected override int Damage(Monster monster)
        {
            int monsterLevel = monster.Race.Level >= 1 ? monster.Race.Level : 1;
            return Program.Rng.DiceRoll(12, 2) + (monsterLevel / 3);
        }
        protected override Projectile Projectile(SaveGame saveGame) => new PoisProjectile(saveGame);
        public override SpellResistantDetection[] SmartLearn => new SpellResistantDetection[] { new PoisSpellResistantDetection(), new ReflectSpellResistantDetection() };
    }
}
