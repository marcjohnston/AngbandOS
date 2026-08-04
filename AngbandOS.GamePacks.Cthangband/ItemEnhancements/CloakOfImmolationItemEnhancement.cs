namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CloakOfImmolationItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResFireAttribute), "true"),
        (nameof(ShFireAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "4000"),
        (nameof(TreasureRatingAttribute), "16"),
        (nameof(BonusArmorClassAttribute), "1d4"),
    };
    public override string? FriendlyName => "of Immolation";
}
