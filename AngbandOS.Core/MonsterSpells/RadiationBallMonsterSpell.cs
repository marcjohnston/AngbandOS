﻿using AngbandOS.Projection;

namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class RadiationBallMonsterSpell : BallProjectileMonsterSpell
    {
        public override bool IsInnate => true;
        public override bool UsesRadiation => true;
        public override bool IsAttack => true;
        protected override string ActionName => "casts a ball of radiation";
        protected override Projectile Projectile(SaveGame saveGame) => new ProjectNuke(saveGame);
        protected override int Damage(Monster monster)
        {
            int monsterLevel = monster.Race.Level >= 1 ? monster.Race.Level : 1;
            return monsterLevel + Program.Rng.DiceRoll(10, 6);
        }
        public override int[] SmartLearn => new int[] { Constants.DrsPois };
    }
}