namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ArmorOfResistFireItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResFireAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "800"),
        (nameof(TreasureRatingAttribute), "14"),
    };
    public override string? FriendlyName => "of Resist Fire";
}
