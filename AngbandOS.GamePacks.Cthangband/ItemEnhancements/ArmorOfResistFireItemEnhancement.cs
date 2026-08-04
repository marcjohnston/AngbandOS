namespace AngbandOS.GamePacks.Cthangband;

public class ArmorOfResistFireItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResFireAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "800"),
        (nameof(TreasureRatingAttribute), "14"),
    };
    public override string? FriendlyName => "of Resist Fire";
}
