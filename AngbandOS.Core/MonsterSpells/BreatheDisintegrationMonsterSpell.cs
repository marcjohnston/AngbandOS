namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class BreatheDisintegrationMonsterSpell : BreatheProjectileMonsterSpell
    {
        protected override string ElementName => "disintegration";
        protected override Projectile Projectile(SaveGame saveGame) => new ProjectDisintegrate(saveGame);
        protected override int Damage(Monster monster) => monster.Health / 3 > 300 ? 300 : monster.Health / 3;
    }
}
