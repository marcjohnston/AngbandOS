using AngbandOS.Projection;
using AngbandOS.Core.SpellResistantDetections;

namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class BreatheDarkMonsterSpell : BreatheProjectileMonsterSpell
    {
        public override bool UsesDarkness => true;
        protected override string ElementName => "darkness";
        protected override Projectile Projectile(SaveGame saveGame) => new ProjectDark(saveGame);
        protected override int Damage(Monster monster) => monster.Health / 6 > 400 ? 400 : monster.Health / 6;
        public override SpellResistantDetection[] SmartLearn => new SpellResistantDetection[] { new DarkSpellResistantDetection() };
    }
}
