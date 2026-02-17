namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class FreeActionRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override bool? FreeAct => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "2"),
        (nameof(ValueAttribute), "1500"),
    };
    public override string? HatesElectricity => "true";
}
