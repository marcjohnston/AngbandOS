namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SlayingRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ShowMods => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "2"),
        (nameof(ValueAttribute), "1000"),
    };
    public override string? HatesElectricity => "true";
}
