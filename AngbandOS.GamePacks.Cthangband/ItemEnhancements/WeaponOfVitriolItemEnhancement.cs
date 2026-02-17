namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponOfVitriolItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(BrandAcidAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(ResAcidAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "8000"),
        (nameof(TreasureRatingAttribute), "15"),
    };
    public override string? FriendlyName => "of Vitriol";
    }
