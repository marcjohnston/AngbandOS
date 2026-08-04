namespace AngbandOS.GamePacks.Cthangband;

public class WeaponOfEvilBaneItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(BlessedAttribute), "true"),
        (nameof(SlayEvilAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "5000"),
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(WisdomAttribute), "1d2"),
    };
    public override string? FriendlyName => "of Evil Bane";
}
