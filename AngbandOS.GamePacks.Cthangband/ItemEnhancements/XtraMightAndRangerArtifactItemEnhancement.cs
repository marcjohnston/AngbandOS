namespace AngbandOS.GamePacks.Cthangband;

public class XtraMightAndRangerArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(XtraMightAttribute), "true"),
    };
    public override string? ArtifactBiasWeightedRandomBindingKey => nameof(Ranger1In9ArtifactBiasWeightedRandom);
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "2250"),
    };
}
