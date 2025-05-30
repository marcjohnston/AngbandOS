﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Death;

[Serializable]
internal class WordOfDeathDeathSpell : Spell
{
    private WordOfDeathDeathSpell(Game game) : base(game) { }
    protected override string[]? CastScriptNames => new string[] { nameof(DispelLivingAtLos3xProjectileScript) };

    protected override string[]? CastFailedScriptNames => new string[] { nameof(WildDeathMagicScript) };

    public override string Name => "Word of Death";

    protected override string LearnedDetails => $"dam {Game.ExperienceLevel.IntValue * 3}";
}