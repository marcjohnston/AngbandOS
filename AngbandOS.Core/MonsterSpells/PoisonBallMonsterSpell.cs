using AngbandOS.Projection;

namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class PoisonBallMonsterSpell : BallProjectileMonsterSpell
    {
        public override bool UsesPoison => true;
        public override bool IsAttack => true;
        protected override string ActionName => "casts a stinking cloud";
        protected override Projectile Projectile(SaveGame saveGame) => new ProjectPois(saveGame);
        protected override int Damage(Monster monster)
        {
            int monsterLevel = monster.Race.Level >= 1 ? monster.Race.Level : 1;
            return Program.Rng.DiceRoll(12, 2);
        }
        public override int[] SmartLearn => new int[] { Constants.DrsPois };
    }
}
