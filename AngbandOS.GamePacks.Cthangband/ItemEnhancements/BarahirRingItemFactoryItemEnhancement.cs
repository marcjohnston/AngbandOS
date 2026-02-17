namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BarahirRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "2"),
        (nameof(ValueAttribute), "65000"),
    };
    public override string? HatesElectricity => "true";
}
