namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class BreatheInertiaMonsterSpell : BreatheProjectileMonsterSpell
{
    protected override string ElementName => "inertia";
    protected override Projectile Projectile(SaveGame saveGame) => saveGame.SingletonRepository.Projectiles.Get<InertiaProjectile>();
    protected override int Damage(Monster monster) => monster.Health / 6 > 200 ? 200 : monster.Health / 6;
}
