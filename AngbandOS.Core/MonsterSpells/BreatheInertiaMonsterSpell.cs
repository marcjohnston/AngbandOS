﻿using AngbandOS.Projection;

namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class BreatheInertiaMonsterSpell : BreatheProjectileMonsterSpell
    {
        protected override string ElementName => "inertia";
        protected override Projectile Projectile(SaveGame saveGame) => new ProjectInertia(saveGame);
        protected override int Damage(Monster monster) => monster.Health / 6 > 200 ? 200 : monster.Health / 6;
    }
}