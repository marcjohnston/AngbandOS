namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class IronHelmItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HatesAcidAttribute), "true"),
        (nameof(ReflectAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "75"),
        (nameof(ValueAttribute), "75"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(DiceSidesAttribute), "3"),
        (nameof(BaseArmorClassAttribute), "5"),
    };
}
