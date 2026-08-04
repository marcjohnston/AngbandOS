namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HatOfTelepathyItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(TelepathyAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "50000"),
        (nameof(TreasureRatingAttribute), "20"),
    };
    public override string? FriendlyName => "of Telepathy";
}
