namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class BreatheTimeMonsterSpell : BreatheProjectileMonsterSpell
    {
        protected override string ElementName => "time";
        protected override Projectile Projectile(SaveGame saveGame) => new TimeProjectile(saveGame);
        protected override int Damage(Monster monster) => monster.Health / 3 > 150 ? 150 : monster.Health / 3;
    }
}
