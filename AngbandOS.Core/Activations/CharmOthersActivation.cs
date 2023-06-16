namespace AngbandOS.Core.Activations;

/// <summary>
/// Charm multiple monsters.
/// </summary>
[Serializable]
internal class CharmOthersActivation : Activation
{
    private CharmOthersActivation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 25;

    public override string? PreActivationMessage => "";

    public override bool Activate()
    {
        SaveGame.CharmMonsters(SaveGame.Player.Level * 2);
        return true;
    }

    public override int RechargeTime(Player player) => 750;

    public override int Value => 17500;

    public override string Description => "mass charm every 750 turns";

    public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustDex = true;

    public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResShards = true;

    public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Regen = true;
}
