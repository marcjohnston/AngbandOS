namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ChaosResistanceRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HatesElectricityAttribute), "true"),
        (nameof(EasyKnowAttribute), "true"),
        (nameof(ResChaosAttribute), "true"),
        (nameof(ResConfAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "2"),
        (nameof(ValueAttribute), "13000"),
    };
}
