namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BootsWingedItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "250"),
        (nameof(TreasureRatingAttribute), "7"),
    };
    public override bool? Feather => true;
    public override string? FriendlyName => "(Winged)";
}
