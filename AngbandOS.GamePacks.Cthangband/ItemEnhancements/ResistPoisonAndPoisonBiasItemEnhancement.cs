namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ResistPoisonAndPoisonBiasItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResPoisAttribute), "true"),
    };
    public override string? ArtifactBiasWeightedRandomBindingKey => nameof(Poison1In1ArtifactBiasWeightedRandom);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "2500"),
    };
}
