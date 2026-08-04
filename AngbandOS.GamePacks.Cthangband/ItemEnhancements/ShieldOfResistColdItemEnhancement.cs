namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ShieldOfResistColdItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(ResColdAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "600"),
        (nameof(TreasureRatingAttribute), "12"),
    };
    public override string? FriendlyName => "of Resist Cold";
}
