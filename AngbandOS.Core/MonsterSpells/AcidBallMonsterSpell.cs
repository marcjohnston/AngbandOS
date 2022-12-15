using AngbandOS.Projection;

namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class AcidBallMonsterSpell : BallProjectileMonsterSpell
    {
        public override bool UsesAcid => true;
        public override bool IsAttack => true;
        protected override string ActionName => "casts an acid ball";
        protected override Projectile Projectile(SaveGame saveGame) => new ProjectAcid(saveGame);
        protected override int Damage(Monster monster)
        {
            int monsterLevel = monster.Race.Level >= 1 ? monster.Race.Level : 1;
            return Program.Rng.DieRoll(monsterLevel * 3) + 15;
        }
        public override int[] SmartLearn => new int[] { Constants.DrsAcid };
    }
}
