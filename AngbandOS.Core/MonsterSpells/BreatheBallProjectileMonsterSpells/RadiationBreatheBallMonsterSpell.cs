﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class RadiationBreatheBallMonsterSpell : BreatheBallProjectileMonsterSpell
{
    private RadiationBreatheBallMonsterSpell(Game game) : base(game) { }
    public override bool UsesRadiation => true;
    protected override string ActionName => "breathes toxic waste";
    protected override string ProjectileKey => nameof(NukeProjectile);
    protected override int MonsterHealthDamageDivisor => 3;
    protected override int MaxDamage => 800;
    public override SpellResistantDetection[] SmartLearn => new SpellResistantDetection[] { Game.SingletonRepository.Get<SpellResistantDetection>(nameof(PoisSpellResistantDetection)) };
}