using AngbandOS.Core.SpellResistantDetections;
using AngbandOS.Projection;

namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class BreatheChaosMonsterSpell : BreatheProjectileMonsterSpell
    {
        public override bool UsesChaos => true;
        protected override string ElementName => "chaos";
        protected override Projectile Projectile(SaveGame saveGame) => new ProjectChaos(saveGame);
        protected override int Damage(Monster monster) => monster.Health / 6 > 600 ? 600 : monster.Health / 6;
        public override SpellResistantDetection[] SmartLearn => new SpellResistantDetection[] { new ChaosSpellResistantDetection() };
    }
}
