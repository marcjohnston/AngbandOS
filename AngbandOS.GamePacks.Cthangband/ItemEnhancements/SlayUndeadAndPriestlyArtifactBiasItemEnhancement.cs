namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SlayUndeadAndPriestlyArtifactBiasItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(SlayUndeadAttribute), "true"),
    };
    public override string? ArtifactBiasWeightedRandomBindingKey => nameof(Priestly1In9ArtifactBiasWeightedRandom);
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "3500"),
    };
}
