namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WoeRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? IsCursed => true;
    public override bool? HideType => true;
    public override bool? Teleport => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "2"),
        (nameof(ValueAttribute), "-4750"),
    };
    public override string? HatesElectricity => "true";
    public override bool? Valueless => true;
}
