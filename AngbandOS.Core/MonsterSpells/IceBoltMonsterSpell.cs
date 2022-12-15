using AngbandOS.Projection;
using AngbandOS.Core.SpellResistantDetections;

namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class IceBoltMonsterSpell : BoltProjectileMonsterSpell
    {
        public override bool UsesCold => true;
        public override bool CanBeReflected => true;
        public override bool IsAttack => true;
        protected override string ActionName => "casts an ice bolt";
        protected override int Damage(Monster monster)
        {
            int monsterLevel = monster.Race.Level >= 1 ? monster.Race.Level : 1;
            return Program.Rng.DiceRoll(6, 6) + monsterLevel;
        }
        protected override Projectile Projectile(SaveGame saveGame) => new ProjectIce(saveGame);
        public override SpellResistantDetection[] SmartLearn => new SpellResistantDetection[] { new ColdSpellResistantDetection(), new ReflectSpellResistantDetection() };
    }
}
