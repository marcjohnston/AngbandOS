namespace AngbandOS.GamePacks.Cthangband;

public class WeaponOfUndeadBaneItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(SeeInvisAttribute), "true"),
        (nameof(SlayUndeadAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "8000"),
        (nameof(TreasureRatingAttribute), "24"),
        (nameof(WisdomAttribute), "1d2"),
    };
    public override string? FriendlyName => "of Undead Bane";
}
