﻿using AngbandOS.Projection;

namespace AngbandOS.Core.MonsterSpells
{

    [Serializable]
    internal class ShardBallMonsterSpell : BallProjectileMonsterSpell
    {
        public override bool IsInnate => true;
        public override bool UsesShards => true;
        public override bool IsAttack => true;
        protected override string ActionName => "casts a shard ball";
        protected override Projectile Projectile(SaveGame saveGame) => new ProjectShard(saveGame);
        protected override int Damage(Monster monster) => monster.Health / 4 > 800 ? 800 : monster.Health / 4;
        public override int[] SmartLearn => new int[] { Constants.DrsShard };
    }
}