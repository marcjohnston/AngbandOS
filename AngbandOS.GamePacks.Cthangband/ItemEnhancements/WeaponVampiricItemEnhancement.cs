namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponVampiricItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(VampiricAttribute), "true"),
        (nameof(HoldLifeAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "10000"),
        (nameof(TreasureRatingAttribute), "25"),
    };
    public override string? FriendlyName => "(Vampiric)";
}
