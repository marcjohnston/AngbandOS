// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Corporeal;

[Serializable]
internal class CorporealSpellWraithform : Spell
{
    private CorporealSpellWraithform(Game game) : base(game) { }
    protected override string? CastScriptName => nameof(WraithformScript);

    public override string Name => "Wraithform";

    protected override string LearnedDetails => $"dur {Game.ExperienceLevel.Value / 2}+d{Game.ExperienceLevel.Value / 2}";
}