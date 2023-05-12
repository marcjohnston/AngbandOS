namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class BreatheConfusionMonsterSpell : BreatheProjectileMonsterSpell
    {
        public override bool UsesConfusion => true;
        protected override string ElementName => "confusion";
        protected override Projectile Projectile(SaveGame saveGame) => saveGame.SingletonRepository.Projectiles.Get<ConfusionProjectile>();
        protected override int Damage(Monster monster) => monster.Health / 6 > 400 ? 400 : monster.Health / 6;
        public override SpellResistantDetection[] SmartLearn => new SpellResistantDetection[] { new ConfSpellResistantDetection() };
    }
}
