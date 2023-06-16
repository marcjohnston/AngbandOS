// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Nature;

[Serializable]
internal class NatureSpellFirstAid : Spell
{
    private NatureSpellFirstAid(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        SaveGame.Player.RestoreHealth(Program.Rng.DiceRoll(2, 8));
        SaveGame.Player.TimedBleeding.AddTimer(-15);
    }

    public override string Name => "First Aid";
    
    protected override string? Info()
    {
        return "heal 2d8";
    }
}