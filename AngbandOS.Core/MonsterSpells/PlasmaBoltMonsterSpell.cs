using AngbandOS.Projection;

namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class PlasmaBoltMonsterSpell : BoltProjectileMonsterSpell
    {
        public override bool CanBeReflected => true;
        public override bool IsAttack => true;
        protected override string ActionName => "casts a plasma bolt";
        protected override int Damage(Monster monster)
        {
            int monsterLevel = monster.Race.Level >= 1 ? monster.Race.Level : 1;
            return 10 + Program.Rng.DiceRoll(8, 7) + monsterLevel;
        }
        protected override Projectile Projectile(SaveGame saveGame) => new ProjectPlasma(saveGame);
        public override int[] SmartLearn => new int[] { Constants.DrsReflect };
    }
}
