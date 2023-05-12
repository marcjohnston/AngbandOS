namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class BreatheTimeMonsterSpell : BreatheProjectileMonsterSpell
    {
        protected override string ElementName => "time";
        protected override Projectile Projectile(SaveGame saveGame) => saveGame.SingletonRepository.Projectiles.Get<TimeProjectile>();
        protected override int Damage(Monster monster) => monster.Health / 3 > 150 ? 150 : monster.Health / 3;
    }
}
