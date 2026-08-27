namespace AngbandOS.GamePacks.Cthangband;

public class IceRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HatesElectricityAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(ResColdAttribute), "true"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.BallOfCold50r2Every1d20p20DirectionalActivation);
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "2"),
        (nameof(ValueAttribute), "3000"),
        (nameof(BonusArmorClassAttribute), "15"),
    };
}
