namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class IceScrollItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? IgnoreCold => true;
    public override bool? EasyKnow => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "5"),
        (nameof(ValueAttribute), "5000"),
    };
    public override string? HatesAcid => "true";
    public override string? HatesFire => "true";
}
