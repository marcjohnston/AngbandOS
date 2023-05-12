namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class BreatheNexusMonsterSpell : BreatheProjectileMonsterSpell
    {
        public override bool UsesNexus => true;
        protected override string ElementName => "nexus";
        protected override Projectile Projectile(SaveGame saveGame) => saveGame.SingletonRepository.Projectiles.Get<NexusProjectile>();
        protected override int Damage(Monster monster) => monster.Health / 3 > 250 ? 250 : monster.Health / 3;
        public override SpellResistantDetection[] SmartLearn => new SpellResistantDetection[] { new NexusSpellResistantDetection() };
    }
}
