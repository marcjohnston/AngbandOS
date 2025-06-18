namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class IceItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.BallOfCold50r2Every1d20p20DirectionalActivation);
    public override bool IgnoreCold => true;
    public override bool ResCold => true;
}