using AngbandOS.Projection;

namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class WaterBoltMonsterSpell : BoltProjectileMonsterSpell
    {
        public override bool CanBeReflected => true;
        public override bool IsAttack => true;
        protected override string ActionName => "casts a water bolt";
        protected override int Damage(Monster monster)
        {
            int monsterLevel = monster.Race.Level >= 1 ? monster.Race.Level : 1;
            return Program.Rng.DiceRoll(10, 10) + monsterLevel;
        }
        protected override Projectile Projectile(SaveGame saveGame) => new ProjectWater(saveGame);
        public override int[] SmartLearn => new int[] { Constants.DrsReflect };
    }
}
