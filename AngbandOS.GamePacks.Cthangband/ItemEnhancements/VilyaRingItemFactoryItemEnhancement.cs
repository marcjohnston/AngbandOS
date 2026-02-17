namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class VilyaRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "2"),
        (nameof(ValueAttribute), "300000"),
    };
    public override string? HatesElectricity => "true";
}
