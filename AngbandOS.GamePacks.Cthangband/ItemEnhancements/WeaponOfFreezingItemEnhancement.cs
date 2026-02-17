namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponOfFreezingItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(BrandColdAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(ResColdAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "2500"),
        (nameof(TreasureRatingAttribute), "15"),
    };
    public override string? FriendlyName => "of Freezing";
    }
