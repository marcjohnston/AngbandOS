// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Nature;

[Serializable]
internal class NatureSpellResistanceTrue : Spell
{
    private NatureSpellResistanceTrue(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        SaveGame.TimedAcidResistance.AddTimer(SaveGame.Rng.DieRoll(20) + 20);
        SaveGame.TimedLightningResistance.AddTimer(SaveGame.Rng.DieRoll(20) + 20);
        SaveGame.TimedFireResistance.AddTimer(SaveGame.Rng.DieRoll(20) + 20);
        SaveGame.TimedColdResistance.AddTimer(SaveGame.Rng.DieRoll(20) + 20);
        SaveGame.TimedPoisonResistance.AddTimer(SaveGame.Rng.DieRoll(20) + 20);
    }

    public override string Name => "Resistance True";

    protected override string LearnedDetails => "dur 20+d20";
}