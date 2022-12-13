using AngbandOS.Projection;

namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class ManaBallMonsterSpell : BallProjectileMonsterSpell
    {
        public override bool IsAttack => true;

        /// <summary>
        /// Returns a message that the monster mumbles powerfully.
        /// </summary>
        /// <param name="monsterName"></param>
        /// <returns></returns>
        public override string? VsPlayerBlindMessage => $"You hear someone mumble powerfully.";

        /// <summary>
        /// Returns a message that the player hears someone powerfully.  The player does not know either monster.
        /// </summary>
        public override string? VsMonsterUnseenMessage => "You hear someone mumble powerfully.";

        protected override string ActionName => "invokes a mana storm";
        protected override Projectile Projectile(SaveGame saveGame) => new ProjectMana(saveGame);
        protected override int Damage(Monster monster)
        {
            int monsterLevel = monster.Race.Level >= 1 ? monster.Race.Level : 1;
            return (monsterLevel * 5) + Program.Rng.DiceRoll(10, 10);
        }
        protected override int Radius => 4;
    }
}
