namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponOfShockingItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? BrandElec => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "4500"),
        (nameof(TreasureRatingAttribute), "20"),
    };
    public override string? FriendlyName => "of Shocking";
    public override bool? IgnoreElec => true;
    public override bool? ResElec => true;
    }
