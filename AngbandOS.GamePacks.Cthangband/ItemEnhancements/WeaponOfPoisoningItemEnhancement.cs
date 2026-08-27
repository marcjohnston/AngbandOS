namespace AngbandOS.GamePacks.Cthangband;

public class WeaponOfPoisoningItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(BrandPoisAttribute), "true"),
        (nameof(ResPoisAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "4500"),
        (nameof(TreasureRatingAttribute), "20"),
    };
    public override string? FriendlyName => "of Poisoning";
    }
