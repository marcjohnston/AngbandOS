namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TerribleWeaponOfDiggingItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ValuelessAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TunnelAttribute), "-1d5+5"),
        (nameof(ValueAttribute), "1125"),
    };
}
