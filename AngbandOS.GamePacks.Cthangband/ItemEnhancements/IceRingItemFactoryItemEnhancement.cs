namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class IceRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.BallOfCold50r2Every1d20p20DirectionalActivation);
    public override bool? IgnoreCold => true;
    public override bool? ResCold => true;
    public override int? Weight => 2;
    public override int? Value => 3000;
}
