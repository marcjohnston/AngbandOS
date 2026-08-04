namespace AngbandOS.GamePacks.Cthangband;

public class HatOfIntelligenceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(SustIntAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "500"),
        (nameof(TreasureRatingAttribute), "13"),
        (nameof(IntelligenceAttribute), "1d2"),
    };
    public override string? FriendlyName => "of Intelligence";
}
