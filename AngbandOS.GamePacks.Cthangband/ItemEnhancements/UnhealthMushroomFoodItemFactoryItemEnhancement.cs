namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class UnhealthMushroomFoodItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(EasyKnowAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "1"),
        (nameof(ValueAttribute), "50"),
        (nameof(DamageDiceAttribute), "10"),
        (nameof(DiceSidesAttribute), "10"),
    };
}
