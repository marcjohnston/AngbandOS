﻿using AngbandOS.Projection;

namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class BreatheManaMonsterSpell : BreatheProjectileMonsterSpell
    {
        protected override string ElementName => "magical energy";
        protected override Projectile Projectile(SaveGame saveGame) => new ProjectMana(saveGame);
        protected override int Damage(Monster monster) => monster.Health / 3 > 250 ? 250 : monster.Health / 3;
    }
}