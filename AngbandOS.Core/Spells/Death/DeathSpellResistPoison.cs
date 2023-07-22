// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Death;

[Serializable]
internal class DeathSpellResistPoison : Spell
{
    private DeathSpellResistPoison(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        SaveGame.TimedPoisonResistance.AddTimer(Program.Rng.DieRoll(20) + 20);
    }

    public override void CastFailed()
    {
        DoWildDeathMagic(5, 0);
    }

    public override string Name => "Resist Poison";
    
    protected override string? Info()
    {
        return "dur 20+d20";
    }
}