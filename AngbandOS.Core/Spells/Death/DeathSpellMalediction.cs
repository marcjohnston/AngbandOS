// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Death;

[Serializable]
internal class DeathSpellMalediction : Spell
{
    private DeathSpellMalediction(Game game) : base(game) { }
    protected override string? CastScriptName => nameof(MaledictionScript);

    protected override string? CastFailedScriptName => nameof(WildDeathMagicScript);

    public override string Name => "Malediction";

    protected override string LearnedDetails => $"dam {3 + ((Game.ExperienceLevel.Value - 1) / 5)}d3";
}