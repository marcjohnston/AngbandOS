namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class StrengthRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? HideType => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "2"),
        (nameof(ValueAttribute), "500"),
        (nameof(StrengthAttribute), "1")
    };
    public override string? HatesElectricity => "true";
}
