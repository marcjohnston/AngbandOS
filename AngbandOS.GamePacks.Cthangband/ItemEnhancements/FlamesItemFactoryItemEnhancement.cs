namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class FlamesItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.BallOfFire50r2AndResistFire1d20p20DirectionalActivation);
    public override bool IgnoreFire => true;
    public override bool ResFire => true;
}