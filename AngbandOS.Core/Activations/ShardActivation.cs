namespace AngbandOS.Core.Activations;

/// <summary>
/// Shoot a shard ball for 120 + level damage.
/// </summary>
[Serializable]
internal class ShardActivation : DirectionalActivation
{
    private ShardActivation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 0; // TODO: Confirm this artifact does not have a corresponding random chance.  It is only used with biased artifacts.

    public override int RechargeTime(Player player) => 400;

    protected override bool Activate(int direction)
    {
        SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get<ShardProjectile>(), direction, 120 + SaveGame.Player.Level, 2);
        return true;
    }

    public override int Value => 5000;

    public override string Description => "shard ball (120+level) every 400 turns";

    public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustCon = true;

    public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResBlind = true;

    public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.FreeAct = true;
}
