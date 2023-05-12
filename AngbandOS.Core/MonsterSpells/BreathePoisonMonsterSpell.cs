namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class BreathePoisonMonsterSpell : BreatheProjectileMonsterSpell
    {
        public override bool UsesPoison => true;
        protected override string ElementName => "gas";
        protected override Projectile Projectile(SaveGame saveGame) => saveGame.SingletonRepository.Projectiles.Get<PoisProjectile>();
        protected override int Damage(Monster monster) => monster.Health / 3 > 800 ? 800 : monster.Health / 3;
        public override SpellResistantDetection[] SmartLearn => new SpellResistantDetection[] { new PoisSpellResistantDetection() };
    }
}
