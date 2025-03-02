// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Nature;

[Serializable]
internal class NatureSpellNaturesWrath : Spell
{
    private NatureSpellNaturesWrath(Game game) : base(game) { }
    protected override string[]? CastScriptNames => new string[] { nameof(NaturesWrathScript) };

    public override string Name => "Nature's Wrath";

    protected override string LearnedDetails => $"dam {4 * Game.ExperienceLevel.IntValue}+{100 + Game.ExperienceLevel.IntValue}";
}