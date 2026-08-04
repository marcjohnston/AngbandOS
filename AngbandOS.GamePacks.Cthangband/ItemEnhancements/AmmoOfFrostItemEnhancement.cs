namespace AngbandOS.GamePacks.Cthangband;

public class AmmoOfFrostItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(BrandColdAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "25"),
        (nameof(TreasureRatingAttribute), "10"),
    };
    public override string? FriendlyName => "of Frost";
}
