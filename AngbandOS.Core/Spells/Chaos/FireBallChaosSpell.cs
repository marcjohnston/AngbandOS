﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Chaos;

[Serializable]
internal class FireBallChaosSpell : Spell
{
    private FireBallChaosSpell(Game game) : base(game) { }
    protected override string[]? CastScriptNames => new string[] { nameof(Fire1xp55r2ProjectileScript) };

    protected override string[]? CastFailedScriptNames => new string[] { nameof(WildChaoticMagicScript) };

    public override string Name => "Fire Ball";

    protected override string LearnedDetails => $"dam {55 + Game.ExperienceLevel.IntValue}";
}