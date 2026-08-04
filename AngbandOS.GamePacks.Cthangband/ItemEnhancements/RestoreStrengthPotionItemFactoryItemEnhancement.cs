namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RestoreStrengthPotionItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HatesColdAttribute), "true"),
        (nameof(EasyKnowAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "4"),
        (nameof(ValueAttribute), "300"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(DiceSidesAttribute), "1"),
    };
}
