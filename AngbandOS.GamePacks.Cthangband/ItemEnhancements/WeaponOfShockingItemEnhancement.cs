namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponOfShockingItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(BrandElecAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(ResElecAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "4500"),
        (nameof(TreasureRatingAttribute), "20"),
    };
    public override string? FriendlyName => "of Shocking";
    }
