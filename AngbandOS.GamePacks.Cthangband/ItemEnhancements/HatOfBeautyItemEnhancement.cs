namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HatOfBeautyItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(SustChaAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "1000"),
        (nameof(TreasureRatingAttribute), "8"),
        (nameof(CharismaAttribute), "1d4"),
    };
    public override string? FriendlyName => "of Beauty";
}
