namespace AngbandOS.GamePacks.Cthangband;

public class GlovesOfClumsinessItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ValuelessAttribute), "true"),
    };
    public override string? FriendlyName => "of Clumsiness";
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
       (nameof(BonusDexterityAttribute), "1d10"),
    };
}
