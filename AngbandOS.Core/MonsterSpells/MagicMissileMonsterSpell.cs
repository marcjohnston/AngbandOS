using AngbandOS.Projection;

namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class MagicMissileMonsterSpell : BoltProjectileMonsterSpell
    {
        public override bool CanBeReflected => true;
        public override bool IsAttack => true;

        protected override string ActionName => "casts a magic missile";

        protected override int Damage(Monster monster)
        {
            int monsterLevel = monster.Race.Level >= 1 ? monster.Race.Level : 1;
            return Program.Rng.DiceRoll(2, 6) + (monsterLevel / 3);
        }

        protected override Projectile Projectile(SaveGame saveGame) => new ProjectMissile(saveGame);

        public override int[] SmartLearn => new int[] { Constants.DrsReflect };
    }
}
