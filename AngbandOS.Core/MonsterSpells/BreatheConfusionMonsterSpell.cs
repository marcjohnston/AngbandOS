using AngbandOS.Projection;

namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class BreatheConfusionMonsterSpell : BreatheProjectileMonsterSpell
    {
        public override bool UsesConfusion => true;
        protected override string ElementName => "confusion";
        protected override Projectile Projectile(SaveGame saveGame) => new ProjectConfusion(saveGame);
        protected override int Damage(Monster monster) => monster.Health / 6 > 400 ? 400 : monster.Health / 6;
        public override int[] SmartLearn => new int[] { Constants.DrsConf };
    }
}
