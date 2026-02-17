namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponOfBurningItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(BrandFireAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResFireAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "3000"),
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(RadiusAttribute), "3"),
    };
    public override string? FriendlyName => "of Burning";
    }
