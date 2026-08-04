namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AcidBallWandItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HatesElectricityAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "10"),
        (nameof(ValueAttribute), "1650"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(DiceSidesAttribute), "1")
    };
}
