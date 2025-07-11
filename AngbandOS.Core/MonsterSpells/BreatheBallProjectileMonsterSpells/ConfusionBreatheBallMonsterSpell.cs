﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class ConfusionBreatheBallMonsterSpell : BreatheBallProjectileMonsterSpell
{
    private ConfusionBreatheBallMonsterSpell(Game game) : base(game) { }
    public override bool UsesConfusion => true;
    public override string? VsMonsterSeenMessage => "{0} breathes confusion at {3}";
    public override string? VsPlayerActionMessage => "{0} breathes confusion.";
    protected override string ProjectileKey => nameof(ConfusionProjectile);
    protected override int MonsterHealthDamageDivisor => 6;
    protected override int MaxDamage => 400;
    protected override string[] SmartLearnSpellResistantDetectionKeys => new string[] { nameof(ColdSpellResistantDetection) };
}
