﻿using AngbandOS.Projection;

namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class BreatheLightMonsterSpell : BreatheProjectileMonsterSpell
    {
        public override bool UsesLight => true;
        protected override string ElementName => "light";
        protected override Projectile Projectile(SaveGame saveGame) => new ProjectLight(saveGame);
        protected override int Damage(Monster monster) => monster.Health / 6 > 400 ? 400 : monster.Health / 6;
        public override int[] SmartLearn => new int[] { Constants.DrsLight };
    }
}