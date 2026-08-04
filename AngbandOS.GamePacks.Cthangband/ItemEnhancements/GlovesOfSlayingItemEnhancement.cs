namespace AngbandOS.GamePacks.Cthangband;

public class GlovesOfSlayingItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ShowModsAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "1500"),
        (nameof(TreasureRatingAttribute), "17"),
        (nameof(MeleeToHitAttribute), "1d6"),
        (nameof(ToDamageAttribute), "1d6"),
    };
    public override string? FriendlyName => "of Slaying";
}
