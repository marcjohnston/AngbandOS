namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ResistColdRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override bool? IgnoreCold => true;
    public override bool? ResCold => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "2"),
        (nameof(ValueAttribute), "250"),
    };
    public override string? HatesElectricity => "true";
}
