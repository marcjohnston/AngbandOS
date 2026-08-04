namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BrassLanternLightSourceItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HatesFireAttribute), "true"),
        (nameof(EasyKnowAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(RadiusAttribute), "2"),
        (nameof(WeightAttribute), "50"),
        (nameof(ValueAttribute), "35"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(DiceSidesAttribute), "1"),
        (nameof(BurnRateAttribute), "1"),
    };
}
