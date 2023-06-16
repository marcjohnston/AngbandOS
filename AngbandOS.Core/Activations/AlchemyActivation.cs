namespace AngbandOS.Core.Activations;

/// <summary>
/// Turn an item to gold.
/// </summary>
[Serializable]
internal class AlchemyActivation : Activation
{
    private AlchemyActivation(SaveGame saveGame) : base(saveGame) { }

    public override int RandomChance => 5;

    public override string? PreActivationMessage => "It glows bright yellow...";

    public override bool Activate()
    {
        SaveGame.Alchemy();
        return true;
    }

    public override int RechargeTime(Player player) => 500;

    public override int Value => 10000;

    public override string Description => "alchemy every 500 turns";

    public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustDex = true;

    public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResSound = true;

    public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Telepathy = true;
}
