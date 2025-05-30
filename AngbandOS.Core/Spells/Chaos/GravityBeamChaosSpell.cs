﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Chaos;

[Serializable]
internal class GravityBeamChaosSpell : Spell
{
    private GravityBeamChaosSpell(Game game) : base(game) { }
    protected override string[]? CastScriptNames => new string[] { nameof(GravityBeamScript) };

    protected override string[]? CastFailedScriptNames => new string[] { nameof(WildChaoticMagicScript) };

    public override string Name => "Gravity Beam";

    protected override string LearnedDetails => $"dam {9 + ((Game.ExperienceLevel.IntValue - 5) / 4)}d8";
}