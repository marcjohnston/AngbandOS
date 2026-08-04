namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HatOfUglinessItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ValuelessAttribute), "true"),
    };
    public override string? FriendlyName => "of Ugliness";
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(CharismaAttribute), "1d5"),
        (nameof(ValueAttribute), "1350"),
    };
}
