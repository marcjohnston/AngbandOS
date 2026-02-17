namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class StupidityRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? IsCursed => true;
    public override bool? HideType => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "2"),
        (nameof(ValueAttribute), "-5000"),
    };
    public override string? HatesElectricity => "true";
    public override bool? Valueless => true;
}
