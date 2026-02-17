namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class XtraMightAndRangerArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(XtraMightAttribute), "true"),
    };
    public override string? ArtifactBiasWeightedRandomBindingKey => nameof(Ranger1In9ArtifactBiasWeightedRandom);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "2250"),
    };
}
