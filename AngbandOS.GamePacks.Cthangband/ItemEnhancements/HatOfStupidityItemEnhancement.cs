namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HatOfStupidityItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ValuelessAttribute), "true"),
    };
    public override string? FriendlyName => "of Stupidity";
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(IntelligenceAttribute), "1d5"),
        (nameof(ValueAttribute), "3600"),
    };
}
