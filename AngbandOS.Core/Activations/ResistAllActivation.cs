// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Give us temporary resistance to the basic elements.
/// </summary>
[Serializable]
internal class ResistAllActivation : Activation
{
    private ResistAllActivation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 85;

    public override string? PreActivationMessage => "It glows many colours...";

    public override bool Activate()
    {
        SaveGame.Player.TimedAcidResistance.AddTimer(Program.Rng.DieRoll(40) + 40);
        SaveGame.Player.TimedLightningResistance.AddTimer(Program.Rng.DieRoll(40) + 40);
        SaveGame.Player.TimedFireResistance.AddTimer(Program.Rng.DieRoll(40) + 40);
        SaveGame.Player.TimedColdResistance.AddTimer(Program.Rng.DieRoll(40) + 40);
        SaveGame.Player.TimedPoisonResistance.AddTimer(Program.Rng.DieRoll(40) + 40);
        return true;
    }

    public override int RechargeTime() => 200;

    public override int Value => 5000;

    public override string Description => "resist elements (dur 40+d40) every 200 turns";

    public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustCon = true;

    public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResChaos = true;

    public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.FreeAct = true;
}
