namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BlindnessResistanceRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override bool? ResBlind => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "2"),
        (nameof(ValueAttribute), "7500"),
    };
    public override string? HatesElectricity => "true";
}
