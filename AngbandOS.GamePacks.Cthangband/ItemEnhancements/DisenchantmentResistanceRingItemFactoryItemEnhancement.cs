namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DisenchantmentResistanceRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override bool? ResDisen => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "2"),
        (nameof(ValueAttribute), "15000"),
    };
    public override string? HatesElectricity => "true";
}
