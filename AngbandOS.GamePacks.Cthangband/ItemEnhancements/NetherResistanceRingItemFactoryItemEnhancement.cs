namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class NetherResistanceRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override bool? HoldLife => true;
    public override bool? ResNether => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "2"),
        (nameof(ValueAttribute), "14500"),
    };
    public override string? HatesElectricity => "true";
}
