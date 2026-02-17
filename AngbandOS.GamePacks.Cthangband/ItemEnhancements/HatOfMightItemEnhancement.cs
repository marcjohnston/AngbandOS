namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HatOfMightItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(FreeActAttribute), "true"),
        (nameof(SustConAttribute), "true"),
        (nameof(SustDexAttribute), "true"),
        (nameof(SustStrAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "2000"),
        (nameof(TreasureRatingAttribute), "19"),
        (nameof(WisdomAttribute), "1d3"),
        (nameof(StrengthAttribute), "1d3")
    };
    public override string? FriendlyName => "of Might";
}
