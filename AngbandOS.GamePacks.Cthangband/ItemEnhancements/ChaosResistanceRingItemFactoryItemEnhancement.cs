namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ChaosResistanceRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override bool? ResChaos => true;
    public override bool? ResConf => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "2"),
        (nameof(ValueAttribute), "13000"),
    };
    public override string? HatesElectricity => "true";
}
