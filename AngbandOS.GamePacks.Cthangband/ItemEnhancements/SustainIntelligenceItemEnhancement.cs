namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SustainIntelligenceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? SustInt => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "850"),
    };
}
