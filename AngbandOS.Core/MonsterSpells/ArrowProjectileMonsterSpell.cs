using AngbandOS.Projection;

namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal abstract class ArrowProjectileMonsterSpell : BoltProjectileMonsterSpell
    {
        public override bool IsInnate => true;
        public override bool CanBeReflected => true;
        public override bool IsAttack => true;
        /// <summary>
        /// Returns a message that the monster is making some strange noise.
        /// </summary>
        /// <param name="monsterName"></param>
        /// <returns></returns>
        public override string? VsPlayerBlindMessage => $"You hear a strange noise.";
        protected override string ActionName => "fires an arrow";
        protected override Projectile Projectile(SaveGame saveGame) => new ProjectArrow(saveGame);
        public override int[] SmartLearn => new int[] { Constants.DrsReflect };
    }
}
