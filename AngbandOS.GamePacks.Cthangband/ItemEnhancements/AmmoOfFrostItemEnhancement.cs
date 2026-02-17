namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AmmoOfFrostItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? BrandCold => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "25"),
        (nameof(TreasureRatingAttribute), "10"),
    };
    public override string? FriendlyName => "of Frost";
    public override bool? IgnoreCold => true;
}
