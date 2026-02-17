namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TeleportationRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? IsCursed => true;
    public override bool? EasyKnow => true;
    public override bool? Teleport => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "2"),
        (nameof(ValueAttribute), "250"),
    };
    public override string? HatesElectricity => "true";
}
