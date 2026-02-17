namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SeeInvisibleRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override bool? SeeInvis => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "2"),
        (nameof(ValueAttribute), "340"),
    };
    public override string? HatesElectricity => "true";
}
