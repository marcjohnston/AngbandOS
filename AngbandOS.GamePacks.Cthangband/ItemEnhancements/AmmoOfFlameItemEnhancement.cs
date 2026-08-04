namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AmmoOfFlameItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(BrandFireAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "30"),
        (nameof(TreasureRatingAttribute), "10"),
    };
    public override string? FriendlyName => "of Flame";
}
