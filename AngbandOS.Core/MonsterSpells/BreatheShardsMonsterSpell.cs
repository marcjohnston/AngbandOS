namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class BreatheShardsMonsterSpell : BreatheProjectileMonsterSpell
    {
        public override bool UsesShards => true;
        protected override string ElementName => "shards";
        protected override Projectile Projectile(SaveGame saveGame) => saveGame.SingletonRepository.Projectiles.Get<ExplodeProjectile>();
        protected override int Damage(Monster monster) => monster.Health / 6 > 400 ? 400 : monster.Health / 6;
        public override SpellResistantDetection[] SmartLearn => new SpellResistantDetection[] { new ShardSpellResistantDetection() };
    }
}
