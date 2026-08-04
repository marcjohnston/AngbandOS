namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LargeWoodenChestItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HatesAcidAttribute), "true"),
        (nameof(HatesFireAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "500"),
        (nameof(ValueAttribute), "60"),
        (nameof(DamageDiceAttribute), "2"),
        (nameof(DiceSidesAttribute), "5"),
    };
}
