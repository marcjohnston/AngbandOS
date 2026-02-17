namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SoundResistanceRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ResSound => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "2"),
        (nameof(ValueAttribute), "3000"),
    };
    public override string? HatesElectricity => "true";
}
