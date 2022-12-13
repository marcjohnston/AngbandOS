using AngbandOS.Projection;

namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class FireBoltMonsterSpell : BoltProjectileMonsterSpell
    {
        public override bool UsesFire => true;
        public override bool CanBeReflected => true;
        public override bool IsAttack => true;
        protected override string ActionName => "casts a fire bolt";
        protected override int Damage(Monster monster)
        {
            int monsterLevel = monster.Race.Level >= 1 ? monster.Race.Level : 1;
            return Program.Rng.DiceRoll(9, 8) + (monsterLevel / 3);
        }
        protected override Projectile Projectile(SaveGame saveGame) => new ProjectFire(saveGame);
        public override int[] SmartLearn => new int[] { Constants.DrsFire, Constants.DrsReflect };
    }
}
