namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SustainIntelligenceRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override bool? SustInt => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "2"),
        (nameof(ValueAttribute), "600"),
    };
    public override string? HatesElectricity => "true";
}
