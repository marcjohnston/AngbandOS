﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Death;

[Serializable]
internal class DarkBoltDeathSpell : Spell
{
    private DarkBoltDeathSpell(Game game) : base(game) { }
    protected override string[]? CastScriptNames => new string[] { nameof(DarkBoltScript) };

    protected override string[]? CastFailedScriptNames => new string[] { nameof(WildDeathMagicScript) };

    public override string Name => "Dark Bolt";

    protected override string LearnedDetails => $"dam {4 + ((Game.ExperienceLevel.IntValue - 5) / 4)}d8";
}