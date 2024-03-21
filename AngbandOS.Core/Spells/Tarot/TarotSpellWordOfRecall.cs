// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Tarot;

[Serializable]
internal class TarotSpellWordOfRecall : Spell
{
    private TarotSpellWordOfRecall(Game game) : base(game) { }
    protected override string? CastScriptName => nameof(ToggleRecallScript);

    public override string Name => "Word of Recall";

    protected override string LearnedDetails => "delay 15+d21";
}