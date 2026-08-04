namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class StarEssenceGaladrielLightSourceItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HatesFireAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(RadiusAttribute), "2"),
        (nameof(WeightAttribute), "10"),
        (nameof(ValueAttribute), "10000"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(DiceSidesAttribute), "1"),
    };
}
