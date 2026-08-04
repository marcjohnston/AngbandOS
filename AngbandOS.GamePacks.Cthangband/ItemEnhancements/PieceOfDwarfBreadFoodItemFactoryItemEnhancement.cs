namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PieceOfDwarfBreadFoodItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(EasyKnowAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "3"),
        (nameof(ValueAttribute), "16"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(DiceSidesAttribute), "6"),
    };
}
