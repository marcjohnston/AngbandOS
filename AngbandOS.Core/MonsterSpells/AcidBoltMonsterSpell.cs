using AngbandOS.Core.SpellResistantDetections;
using AngbandOS.Projection;

namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class AcidBoltMonsterSpell : BoltProjectileMonsterSpell
    {
        public override bool UsesAcid => true;
        public override bool CanBeReflected => true;
        public override bool IsAttack => true;
        protected override string ActionName => "casts a acid bolt";
        protected override int Damage(Monster monster)
        {
            int monsterLevel = monster.Race.Level >= 1 ? monster.Race.Level : 1;
            return Program.Rng.DiceRoll(7, 8) + (monsterLevel / 3);
        }
        protected override Projectile Projectile(SaveGame saveGame) => new ProjectAcid(saveGame);
        public override SpellResistantDetection[] SmartLearn => new SpellResistantDetection[] { new AcidSpellResistantDetection(), new ReflectSpellResistantDetection() };
    }
}
