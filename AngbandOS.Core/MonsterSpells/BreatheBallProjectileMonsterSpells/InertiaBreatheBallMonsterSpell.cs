﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class InertiaBreatheBallMonsterSpell : BreatheBallProjectileMonsterSpell
{
    private InertiaBreatheBallMonsterSpell(Game game) : base(game) { }
    protected override string ActionName => "breathes inertia";
    protected override string ProjectileKey => nameof(InertiaProjectile);
    protected override int MonsterHealthDamageDivisor => 6;
    protected override int MaxDamage => 200;
}