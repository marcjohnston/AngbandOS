﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Sorcery;

[Serializable]
internal class HasteSelfSorcerySpell : Spell
{
    private HasteSelfSorcerySpell(Game game) : base(game) { }
    protected override string[]? CastScriptNames => new string[] { nameof(HasteScript) };

    public override string Name => "Haste Self";

    protected override string LearnedDetails => $"dur {Game.ExperienceLevel.IntValue}+d{Game.ExperienceLevel.IntValue + 20}";
}