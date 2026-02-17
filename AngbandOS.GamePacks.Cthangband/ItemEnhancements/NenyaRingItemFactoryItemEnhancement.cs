namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class NenyaRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "2"),
        (nameof(ValueAttribute), "200000"),
    };
    public override string? HatesElectricity => "true";
}
