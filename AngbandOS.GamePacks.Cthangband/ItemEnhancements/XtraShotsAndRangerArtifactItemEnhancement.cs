namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class XtraShotsAndRangerArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(XtraShotsAttribute), "true"),
    };
    public override string? ArtifactBiasWeightedRandomBindingKey => nameof(Ranger1In9ArtifactBiasWeightedRandom);
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "10000"),
    };
}
