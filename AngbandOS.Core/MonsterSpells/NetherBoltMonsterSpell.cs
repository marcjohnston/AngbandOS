namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class NetherBoltMonsterSpell : BoltProjectileMonsterSpell
    {
        public override bool UsesNether => true;

        public override bool CanBeReflected => true;
        public override bool IsAttack => true;
        protected override string ActionName => "casts a nether bolt";
        protected override int Damage(Monster monster)
        {
            int monsterLevel = monster.Race.Level >= 1 ? monster.Race.Level : 1;
            return 30 + Program.Rng.DiceRoll(5, 5) + (monsterLevel * 3 / 2);
        }
        protected override Projectile Projectile(SaveGame saveGame) => new NetherProjectile(saveGame);
        public override SpellResistantDetection[] SmartLearn => new SpellResistantDetection[] { new NethSpellResistantDetection(), new ReflectSpellResistantDetection() };
    }
}
