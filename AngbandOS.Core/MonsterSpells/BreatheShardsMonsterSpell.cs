﻿using AngbandOS.Projection;

namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class BreatheShardsMonsterSpell : BreatheProjectileMonsterSpell
    {
        public override bool UsesShards => true;
        protected override string ElementName => "shards";
        protected override Projectile Projectile(SaveGame saveGame) => new ProjectExplode(saveGame);
        protected override int Damage(Monster monster) => monster.Health / 6 > 400 ? 400 : monster.Health / 6;
        public override int[] SmartLearn => new int[] { Constants.DrsShard };
    }
}