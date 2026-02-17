namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AmmoOfFlameItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? BrandFire => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "30"),
        (nameof(TreasureRatingAttribute), "10"),
    };
    public override string? FriendlyName => "of Flame";
    public override bool? IgnoreFire => true;
}
