namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ShardResistanceRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override bool? ResShards => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "2"),
        (nameof(ValueAttribute), "3000"),
    };
    public override string? HatesElectricity => "true";
}
