namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class BreatheNetherMonsterSpell : BreatheProjectileMonsterSpell
    {
        public override bool UsesNether => true;
        protected override string ElementName => "nether";
        protected override Projectile Projectile(SaveGame saveGame) => saveGame.SingletonRepository.Projectiles.Get<NetherProjectile>();
        protected override int Damage(Monster monster) => monster.Health / 6 > 550 ? 550 : monster.Health / 6;
        public override SpellResistantDetection[] SmartLearn => new SpellResistantDetection[] { new NethSpellResistantDetection() };
    }
}
