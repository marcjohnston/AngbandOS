using AngbandOS.Projection;

namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class BreatheAcidMonsterSpell : BreatheProjectileMonsterSpell
    {
        public override bool UsesAcid => true;
        protected override string ElementName => "acid";
        protected override Projectile Projectile(SaveGame saveGame) => new ProjectAcid(saveGame);
        protected override int Damage(Monster monster) => monster.Health / 3 > 1600 ? 1600 : monster.Health / 3;
        public override int[] SmartLearn => new int[] { Constants.DrsAcid };
    }
}
