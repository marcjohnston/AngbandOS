namespace AngbandOS.Core.Activations;

/// <summary>
/// Detect everything.
/// </summary>
[Serializable]
internal class DetectAllActivation : Activation
{
    private DetectAllActivation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 85;

    public override string? PreActivationMessage => "It glows bright white...";

    public override bool Activate()
    {
        SaveGame.MsgPrint("An image forms in your mind...");
        SaveGame.DetectAll();
        return true;
    }

    public override int RechargeTime(Player player) => Program.Rng.RandomLessThan(55) + 55;

    public override int Value => 1000;

    public override string Description => "detection every 55+d55 turns";

    public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustCha = true;

    public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResShards = true;

    public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Lightsource = true;
}
