// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Life;

[Serializable]
internal class LifeSpellHolyWord : Spell
{
    private LifeSpellHolyWord(Game game) : base(game) { }
    protected override string? CastScriptName => nameof(HolyWordScript);

    public override string Name => "Holy Word";

    protected override string LearnedDetails => $"d {4 * Game.ExperienceLevel.IntValue}/h 1000";
}