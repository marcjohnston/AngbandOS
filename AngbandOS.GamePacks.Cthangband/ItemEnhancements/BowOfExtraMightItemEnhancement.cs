namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BowOfExtraMightItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(XtraMightAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "10000"),
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(MeleeToHitAttribute), "1d5"),
        (nameof(ToDamageAttribute), "1d10"),
    };
    public override string? FriendlyName => "of Extra Might";
}
