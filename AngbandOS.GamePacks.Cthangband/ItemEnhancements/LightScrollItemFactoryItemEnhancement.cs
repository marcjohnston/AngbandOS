namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LightScrollItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "5"),
        (nameof(ValueAttribute), "15"),
    };
    public override string? HatesAcid => "true";
    public override string? HatesFire => "true";
}
