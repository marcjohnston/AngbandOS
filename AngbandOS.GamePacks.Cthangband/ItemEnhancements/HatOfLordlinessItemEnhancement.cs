namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HatOfLordlinessItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(SustChaAttribute), "true"),
        (nameof(SustWisAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "2000"),
        (nameof(TreasureRatingAttribute), "17"),
        (nameof(WisdomAttribute), "1d3"),
        (nameof(CharismaAttribute), "1d3"),
    };
    public override string? FriendlyName => "of Lordliness";
}
