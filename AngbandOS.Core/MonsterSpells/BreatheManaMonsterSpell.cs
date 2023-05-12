namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class BreatheManaMonsterSpell : BreatheProjectileMonsterSpell
    {
        protected override string ElementName => "magical energy";
        protected override Projectile Projectile(SaveGame saveGame) => saveGame.SingletonRepository.Projectiles.Get<ManaProjectile>();
        protected override int Damage(Monster monster) => monster.Health / 3 > 250 ? 250 : monster.Health / 3;
    }
}
