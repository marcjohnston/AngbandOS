namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponOfDiggingItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? BrandAcid => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "500"),
        (nameof(TreasureRatingAttribute), "4"),
        (nameof(TunnelAttribute), "1d5"),
    };
    public override string? FriendlyName => "of Digging";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
}
