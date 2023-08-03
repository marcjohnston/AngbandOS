// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Tarot;

[Serializable]
internal class TarotSpellAstralSpying : Spell
{
    private TarotSpellAstralSpying(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        SaveGame.TimedTelepathy.AddTimer(SaveGame.Rng.DieRoll(30) + 25);
    }

    public override string Name => "Astral Spying";
    
    protected override string? Info()
    {
        return "dur 25+d30";
    }
}