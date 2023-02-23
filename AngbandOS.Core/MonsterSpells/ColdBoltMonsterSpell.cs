namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class ColdBoltMonsterSpell : BoltProjectileMonsterSpell
    {
        public override bool UsesCold => true;
        public override bool CanBeReflected => true;
        public override bool IsAttack => true;

        protected override string ActionName => "casts a frost bolt";
        protected override int Damage(Monster monster)
        {
            int monsterLevel = monster.Race.Level >= 1 ? monster.Race.Level : 1;
            return Program.Rng.DiceRoll(6, 8) + (monsterLevel / 3);
        }
        protected override Projectile Projectile(SaveGame saveGame) => new ColdProjectile(saveGame);
        public override SpellResistantDetection[] SmartLearn => new SpellResistantDetection[] { new ColdSpellResistantDetection(), new ReflectSpellResistantDetection() };
    }
}
