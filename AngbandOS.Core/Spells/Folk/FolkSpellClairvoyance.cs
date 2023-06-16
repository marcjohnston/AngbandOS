// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Folk;

[Serializable]
internal class FolkSpellClairvoyance : Spell
{
    private FolkSpellClairvoyance(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        SaveGame.Level.WizLight();
        if (!SaveGame.Player.HasTelepathy)
        {
            SaveGame.Player.TimedTelepathy.AddTimer(Program.Rng.DieRoll(30) + 25);
        }
    }

    public override string Name => "Clairvoyance";
    
    protected override string? Info()
    {
        return "dur 25+d30";
    }
}