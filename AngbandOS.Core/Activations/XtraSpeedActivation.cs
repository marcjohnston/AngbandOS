namespace AngbandOS.Core.Activations;

/// <summary>
/// Give us extra haste for a long time.
/// </summary>
[Serializable]
internal class XtraSpeedActivation : Activation
{
    private XtraSpeedActivation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 10;

    public override string? PreActivationMessage => "It glows brightly...";

    public override bool Activate()
    {
        if (SaveGame.Player.TimedHaste.TurnsRemaining == 0)
        {
            SaveGame.Player.TimedHaste.SetTimer(Program.Rng.DieRoll(75) + 75);
        }
        else
        {
            SaveGame.Player.TimedHaste.AddTimer(5);
        }
        return true;
    }

    public override int RechargeTime(Player player) => Program.Rng.RandomLessThan(200) + 200;

    public override int Value => 25000;

    public override string Description => "speed (dur 75+d75) every 200+d200 turns";

    public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustStr = true;

    public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResPois = true;

    public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Feather = true;
}
