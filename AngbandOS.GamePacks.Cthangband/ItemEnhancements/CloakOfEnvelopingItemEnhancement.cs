namespace AngbandOS.GamePacks.Cthangband;

public class CloakOfEnvelopingItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ValuelessAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
    };
    public override string? FriendlyName => "of Enveloping";
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ToDamageAttribute), "1d10"),
        (nameof(MeleeToHitAttribute), "1d10"),
    };
}
