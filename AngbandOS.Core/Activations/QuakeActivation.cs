namespace AngbandOS.Core.Activations;

/// <summary>
/// Cause an earthquake around the player.
/// </summary>
[Serializable]
internal class QuakeActivation : Activation
{
    private QuakeActivation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 101;

    public override string? PreActivationMessage => "";

    public override int RechargeTime(Player player) => 50;

    public override bool Activate()
    {
        SaveGame.Earthquake(SaveGame.Player.MapY, SaveGame.Player.MapX, 10);
        return true;
    }

    public override int Value => 600;

    public override string Description => "earthquake (rad 10) every 50 turns";

    public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustCha = true;

    public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResDark = true;

    public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Regen = true;
}
