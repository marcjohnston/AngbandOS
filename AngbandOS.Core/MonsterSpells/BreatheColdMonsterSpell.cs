using AngbandOS.Core.SpellResistantDetections;
using AngbandOS.Projection;

namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class BreatheColdMonsterSpell : BreatheProjectileMonsterSpell
    {
        public override bool UsesCold => true;
        protected override string ElementName => "frost";
        protected override Projectile Projectile(SaveGame saveGame) => new ProjectCold(saveGame);
        protected override int Damage(Monster monster) => monster.Health / 3 > 1600 ? 1600 : monster.Health / 3;
        public override SpellResistantDetection[] SmartLearn => new SpellResistantDetection[] { new ColdSpellResistantDetection() };
    }
}
