namespace AngbandOS.GamePacks.Cthangband;

public class HatOfMightItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(FreeActAttribute), "true"),
        (nameof(SustConAttribute), "true"),
        (nameof(SustDexAttribute), "true"),
        (nameof(SustStrAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "2000"),
        (nameof(TreasureRatingAttribute), "19"),
        (nameof(BonusWisdomAttribute), "1d3"),
        (nameof(BonusStrengthAttribute), "1d3")
    };
    public override string? FriendlyName => "of Might";
}
