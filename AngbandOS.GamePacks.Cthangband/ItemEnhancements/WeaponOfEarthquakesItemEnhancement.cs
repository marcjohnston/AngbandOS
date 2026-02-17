namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponOfEarthquakesItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "4000"),
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(TunnelAttribute), "1d3"),
    };
    public override string? FriendlyName => "of Earthquakes";
    public override bool? Impact => true;
}
