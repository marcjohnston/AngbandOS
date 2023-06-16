namespace AngbandOS.Core.Activations;

/// <summary>
/// Activate the Call Chaos spell.
/// </summary>
[Serializable]
internal class CallChaosActivation : Activation
{
    private CallChaosActivation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 25;

    public override string? PreActivationMessage => "It glows in scintillating colours...";

    public override int RechargeTime(Player player) => 350;

    public override bool Activate()
    {
        SaveGame.CallChaos();
        return true;
    }

    public override int Value => 5000;

    public override string Description => "call chaos every 350 turns";

    public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustDex = true;

    public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResLight = true;

    public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Regen = true;
}
