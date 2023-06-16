namespace AngbandOS.Core.Activations;

/// <summary>
/// Shoot a fire bolt that does 9d8 damage.
/// </summary>
[Serializable]
internal class BoFire1Activation : DirectionalActivation
{
    private BoFire1Activation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 101;

    public override string? PreActivationMessage => "It is covered in fire...";

    public override int RechargeTime(Player player) => Program.Rng.RandomLessThan(8) + 8;

    protected override bool Activate(int direction)
    {
        SaveGame.FireBolt(SaveGame.SingletonRepository.Projectiles.Get<FireProjectile>(), direction, Program.Rng.DiceRoll(9, 8));
        return true;
    }

    public override int Value => 250;

    public override string Description => "fire bolt (9d8) every 8+d8 turns";

    public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustInt = true;

    public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResDisen = true;

    public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.HoldLife = true;
}
