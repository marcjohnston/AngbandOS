namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class BreatheGravityMonsterSpell : BreatheProjectileMonsterSpell
    {
        protected override string ElementName => "gravity";
        protected override Projectile Projectile(SaveGame saveGame) => new ProjectGravity(saveGame);
        protected override int Damage(Monster monster) => monster.Health / 3 > 200 ? 200 : monster.Health / 3;
    }
}
