namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponShatteredItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ValuelessAttribute), "true"),
    };
    public override string? FriendlyName => "(Shattered)";
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ToDamageAttribute), "1d5"),
        (nameof(MeleeToHitAttribute), "1d5"),
    };
}
