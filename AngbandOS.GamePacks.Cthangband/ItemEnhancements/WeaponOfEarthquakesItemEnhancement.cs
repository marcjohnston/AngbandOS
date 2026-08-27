namespace AngbandOS.GamePacks.Cthangband;

public class WeaponOfEarthquakesItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ImpactAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "4000"),
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(TunnelAttribute), "1d3"),
    };
    public override string? FriendlyName => "of Earthquakes";
}
