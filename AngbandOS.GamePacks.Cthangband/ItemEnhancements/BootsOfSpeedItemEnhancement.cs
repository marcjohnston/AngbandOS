namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BootsOfSpeedItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "200000"),
        (nameof(SpeedAttribute), "1d10"),
        (nameof(TreasureRatingAttribute), "25"),
    };
    public override string? FriendlyName => "of Speed";
    public override bool? HideType => true;
}
