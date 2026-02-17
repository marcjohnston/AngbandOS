namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ProtectionRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "2"),
        (nameof(ValueAttribute), "500"),
    };
    public override string? HatesElectricity => "true";
}
