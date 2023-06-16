namespace AngbandOS.Core.Activations;

/// <summary>
/// Shoot a lightning storm that does 250 damage with a larger radius.
/// </summary>
[Serializable]
internal class BaElec3Activation : DirectionalActivation
{
    private BaElec3Activation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 50;

    public override string? PreActivationMessage => "It glows deep blue...";

    public override int RechargeTime(Player player) => Program.Rng.RandomLessThan(425) + 425;

    protected override bool Activate(int direction)
    {
        SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get<ElecProjectile>(), direction, 250, 3);
        return true;
    }

    public override int Value => 2000;

    public override string Description => "ball of lightning (250) every 425+d425 turns";

    public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustStr = true;

    public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResDisen = true;

    public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SeeInvis = true;
}
