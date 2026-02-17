namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AmmoOfShockingItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? BrandElec => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "30"),
        (nameof(TreasureRatingAttribute), "10"),
    };
    public override string? FriendlyName => "of Shocking";
    public override bool? IgnoreElec => true;
}
