namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SustainCharismaRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override bool? SustCha => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "2"),
        (nameof(ValueAttribute), "500"),
    };
    public override string? HatesElectricity => "true";
}
