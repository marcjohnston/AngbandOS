using AngbandOS.Projection;

namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class BreathePlasmaMonsterSpell : BreatheProjectileMonsterSpell
    {
        protected override string ElementName => "plasma";
        protected override Projectile Projectile(SaveGame saveGame) => new ProjectPlasma(saveGame);
        protected override int Damage(Monster monster) => monster.Health / 6 > 150 ? 150 : monster.Health / 6;
    }
}
