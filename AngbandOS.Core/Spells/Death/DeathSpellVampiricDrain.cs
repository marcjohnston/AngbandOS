// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Death;

[Serializable]
internal class DeathSpellVampiricDrain : Spell
{
    private DeathSpellVampiricDrain(Game game) : base(game) { }
    protected override string? CastScriptName => nameof(VampiricDrainScript);

    protected override string? CastFailedScriptName => nameof(WildDeathMagicScript);

    public override string Name => "Vampiric Drain";

    protected override string LearnedDetails => $"dam {Math.Max(1, Game.ExperienceLevel.Value / 10)}d{Game.ExperienceLevel.Value}+{Game.ExperienceLevel.Value}";
}