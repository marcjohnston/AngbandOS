// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Nature;

[Serializable]
internal class NatureSpellResistEnvironment : Spell
{
    private NatureSpellResistEnvironment(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        SaveGame.TimedColdResistance.AddTimer(SaveGame.Rng.DieRoll(20) + 20);
        SaveGame.TimedFireResistance.AddTimer(SaveGame.Rng.DieRoll(20) + 20);
        SaveGame.TimedLightningResistance.AddTimer(SaveGame.Rng.DieRoll(20) + 20);
    }

    public override string Name => "Resist Environment";
    
    protected override string? Info()
    {
        return "dur 20+d20";
    }
}