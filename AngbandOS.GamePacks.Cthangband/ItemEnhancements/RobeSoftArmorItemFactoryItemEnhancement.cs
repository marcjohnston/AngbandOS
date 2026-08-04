namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RobeSoftArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HatesAcidAttribute), "true"),
        (nameof(HatesFireAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "20"),
        (nameof(ValueAttribute), "4"),
        (nameof(BaseArmorClassAttribute), "2"),
    };
}
