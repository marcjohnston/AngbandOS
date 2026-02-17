namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TulkasRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "2"),
        (nameof(ValueAttribute), "150000"),
    };
    public override string? HatesElectricity => "true";
}
