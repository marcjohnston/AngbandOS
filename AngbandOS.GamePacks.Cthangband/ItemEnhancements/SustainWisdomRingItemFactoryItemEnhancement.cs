namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SustainWisdomRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HatesElectricityAttribute), "true"),
        (nameof(EasyKnowAttribute), "true"),
        (nameof(SustWisAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "2"),
        (nameof(ValueAttribute), "600"),
    };
}
