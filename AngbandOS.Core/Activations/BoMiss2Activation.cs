namespace AngbandOS.Core.Activations;

/// <summary>
/// Shoot an arrow that does 150 damage.
/// </summary>
[Serializable]
internal class BoMiss2Activation : DirectionalActivation
{
    private BoMiss2Activation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 66;

    public override string? PreActivationMessage => "It grows magical spikes...";

    public override int RechargeTime(Player player) => Program.Rng.RandomLessThan(90) + 90;

    protected override bool Activate(int direction)
    {
        SaveGame.FireBolt(SaveGame.SingletonRepository.Projectiles.Get<ArrowProjectile>(), direction, 150);
        return true;
    }

    public override int Value => 1000;

    public override string Description => "arrows (150) every 90+d90 turns";

    public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustDex = true;

    public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResNether = true;

    public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.HoldLife = true;
}
