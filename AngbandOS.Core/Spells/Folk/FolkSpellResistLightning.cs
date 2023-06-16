// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Folk;

[Serializable]
internal class FolkSpellResistLightning : Spell
{
    private FolkSpellResistLightning(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        SaveGame.Player.TimedLightningResistance.AddTimer(Program.Rng.DieRoll(20) + 20);
    }

    public override string Name => "Resist Lightning";
    
    protected override string? Info()
    {
        return "dur 20+d20";
    }
}