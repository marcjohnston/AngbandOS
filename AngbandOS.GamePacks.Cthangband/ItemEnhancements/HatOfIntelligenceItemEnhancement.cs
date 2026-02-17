namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HatOfIntelligenceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "500"),
        (nameof(TreasureRatingAttribute), "13"),
        (nameof(IntelligenceAttribute), "1d2"),
    };
    public override string? FriendlyName => "of Intelligence";
    public override bool? SustInt => true;
}
