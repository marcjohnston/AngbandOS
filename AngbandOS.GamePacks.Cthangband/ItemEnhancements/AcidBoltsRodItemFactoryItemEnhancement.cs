namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AcidBoltsRodItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(EasyKnowAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "15"),
        (nameof(ValueAttribute), "3500"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(DiceSidesAttribute), "1")
    };
}
