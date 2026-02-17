namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class FlamesRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HatesElectricityAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResFireAttribute), "true"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.BallOfFire50r2AndResistFire1d20p20DirectionalActivation);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "2"),
        (nameof(ValueAttribute), "1000"),
        (nameof(BonusArmorClassAttribute), "15"),
    };
}
