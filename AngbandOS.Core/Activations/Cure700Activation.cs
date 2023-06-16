namespace AngbandOS.Core.Activations;

/// <summary>
/// Heal 700 health and remove all bleeding.
/// </summary>
[Serializable]
internal class Cure700Activation : Activation
{
    private Cure700Activation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 25;

    public override string? PreActivationMessage => "It glows deep blue...";

    public override bool Activate()
    {
        SaveGame.MsgPrint("You feel a warm tingling inside...");
        SaveGame.Player.RestoreHealth(700);
        SaveGame.Player.TimedBleeding.ResetTimer();
        return true;
    }

    public override int RechargeTime(Player player) => 250;

    public override int Value => 10000;

    public override string Description => "heal 700 hit points every 250 turns";

    public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustWis = true;

    public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResDark = true;

    public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.FreeAct = true;
}
