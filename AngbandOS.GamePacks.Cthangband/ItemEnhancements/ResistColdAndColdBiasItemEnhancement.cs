namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ResistColdAndColdBiasItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResColdAttribute), "true"),
    };
    public override string? ArtifactBiasWeightedRandomBindingKey => nameof(Cold1In1ArtifactBiasWeightedRandom);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "1250"),
    };
}
