namespace AngbandOS.Core.Activations;

/// <summary>
/// Identify an item fully.
/// </summary>
[Serializable]
internal class IdFullActivation : Activation
{
    private IdFullActivation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 25;

    public override string? PreActivationMessage => "It glows yellow...";

    public override bool Activate()
    {
        SaveGame.IdentifyFully();
        return true;
    }

    public override int RechargeTime(Player player) => 750;

    public override int Value => 10000;

    public override string Description => "identify true every 750 turns";

    public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustInt = true;

    public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResNexus = true;

    public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Telepathy = true;
}
