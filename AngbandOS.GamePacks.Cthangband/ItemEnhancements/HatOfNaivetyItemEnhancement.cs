namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HatOfNaivetyItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ValuelessAttribute), "true"),
    };
    public override string? FriendlyName => "of Naivety";
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WisdomAttribute), "1d5"),
        (nameof(ValueAttribute), "3600"),
    };
}
