namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class BreatheSoundMonsterSpell : BreatheProjectileMonsterSpell
    {
        public override bool UsesSound => true;
        protected override string ElementName => "sound";
        protected override Projectile Projectile(SaveGame saveGame) => saveGame.SingletonRepository.Projectiles.Get<SoundProjectile>();
        protected override int Damage(Monster monster) => monster.Health / 6 > 400 ? 400 : monster.Health / 6;
        public override SpellResistantDetection[] SmartLearn => new SpellResistantDetection[] { new SoundSpellResistantDetection() };
    }
}
