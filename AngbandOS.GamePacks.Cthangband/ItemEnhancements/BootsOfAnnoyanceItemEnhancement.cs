namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BootsOfAnnoyanceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(AggravateAttribute), "true"),
        (nameof(ValuelessAttribute), "true"),
    };
    public override string? FriendlyName => "of Annoyance";
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(SpeedAttribute), "1d10"),
        (nameof(ValueAttribute), "89000"),
    };
}
