namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AmmoOfBackbitingItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ValuelessAttribute), "true"),
    };
    public override string? FriendlyName => "of Backbiting";
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ToDamageAttribute), "1d50"),
        (nameof(MeleeToHitAttribute), "1d50"),
    };
}