﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class SoundBreatheBallMonsterSpell : BreatheBallProjectileMonsterSpell
{
    private SoundBreatheBallMonsterSpell(Game game) : base(game) { }
    public override bool UsesSound => true;
    protected override string ActionName => "breathes sound";
    protected override string ProjectileKey => nameof(SoundProjectile);
    protected override int MonsterHealthDamageDivisor => 6;
    protected override int MaxDamage => 400;
    public override SpellResistantDetection[] SmartLearn => new SpellResistantDetection[] { Game.SingletonRepository.Get<SpellResistantDetection>(nameof(SoundSpellResistantDetection)) };
}