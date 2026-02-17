namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SpeedRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "25"),
        (nameof(ValueAttribute), "100000"),
        (nameof(WeightAttribute), "2"),
    };
    public override bool? HideType => true;
    public override string? HatesElectricity => "true";
}
