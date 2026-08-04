namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class FireScrollItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HatesAcidAttribute), "true"),
        (nameof(HatesFireAttribute), "true"),
        (nameof(EasyKnowAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "5"),
        (nameof(ValueAttribute), "1000"),
    };
}
