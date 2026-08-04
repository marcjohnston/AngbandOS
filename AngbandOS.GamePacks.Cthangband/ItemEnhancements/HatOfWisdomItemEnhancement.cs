namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HatOfWisdomItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(SustWisAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "500"),
        (nameof(TreasureRatingAttribute), "13"),
        (nameof(WisdomAttribute), "1d2"),
    };
    public override string? FriendlyName => "of Wisdom";
}
