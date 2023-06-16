namespace AngbandOS.Core.Activations;

/// <summary>
/// Charm an animal.
/// </summary>
[Serializable]
internal class CharmAnimalActivation : DirectionalActivation
{
    private CharmAnimalActivation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 50;

    public override string? PreActivationMessage => "";

    public override int RechargeTime(Player player) => 300;

    protected override bool Activate(int direction)
    {
        SaveGame.CharmAnimal(direction, SaveGame.Player.Level);
        return true;
    }

    public override int Value => 7500;

    public override string Description => "charm animal every 300 turns";

    public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustCha = true;

    public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResLight = true;

    public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Lightsource = true;
}
