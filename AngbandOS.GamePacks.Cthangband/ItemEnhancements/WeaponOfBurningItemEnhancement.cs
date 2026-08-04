namespace AngbandOS.GamePacks.Cthangband;

public class WeaponOfBurningItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(BrandFireAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResFireAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "3000"),
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(RadiusAttribute), "3"),
    };
    public override string? FriendlyName => "of Burning";
    }
