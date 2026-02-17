namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LevitationRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override bool? Feather => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "2"),
        (nameof(ValueAttribute), "200"),
    };
    public override string? HatesElectricity => "true";
}
