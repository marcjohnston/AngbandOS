namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class BreatheForceMonsterSpell : BreatheProjectileMonsterSpell
    {
        protected override string ElementName => "force";
        protected override Projectile Projectile(SaveGame saveGame) => new ProjectForce(saveGame);
        protected override int Damage(Monster monster) => monster.Health / 6 > 200 ? 200 : monster.Health / 6;
    }
}
