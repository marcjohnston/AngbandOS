﻿using AngbandOS.Projection;

namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class NetherBallMonsterSpell : BallProjectileMonsterSpell
    {
        public override bool UsesNether => true;
        public override bool IsAttack => true;
        protected override string ActionName => "casts an nether ball";
        protected override Projectile Projectile(SaveGame saveGame) => new ProjectNether(saveGame);
        protected override int Damage(Monster monster)
        {
            int monsterLevel = monster.Race.Level >= 1 ? monster.Race.Level : 1;
            return 50 + Program.Rng.DiceRoll(10, 10) + monsterLevel;
        }
        public override int[] SmartLearn => new int[] { Constants.DrsNeth };
    }
}