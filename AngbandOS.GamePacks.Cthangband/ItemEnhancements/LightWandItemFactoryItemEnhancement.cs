namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LightWandItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HatesElectricityAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "10"),
        (nameof(ValueAttribute), "200"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(DiceSidesAttribute), "1"),
    };
}
