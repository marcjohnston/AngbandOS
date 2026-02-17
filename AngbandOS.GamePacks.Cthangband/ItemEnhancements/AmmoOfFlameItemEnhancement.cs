namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AmmoOfFlameItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(BrandFireAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "30"),
        (nameof(TreasureRatingAttribute), "10"),
    };
    public override string? FriendlyName => "of Flame";
}
