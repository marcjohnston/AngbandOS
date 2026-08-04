namespace AngbandOS.GamePacks.Cthangband;

public class AmmoOfShockingItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(BrandElecAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "30"),
        (nameof(TreasureRatingAttribute), "10"),
    };
    public override string? FriendlyName => "of Shocking";
}
