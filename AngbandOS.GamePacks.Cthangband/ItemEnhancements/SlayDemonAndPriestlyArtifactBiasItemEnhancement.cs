namespace AngbandOS.GamePacks.Cthangband;

public class SlayDemonAndPriestlyArtifactBiasItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(SlayDemonAttribute), "true"),
    };
    public override string? ArtifactBiasWeightedRandomBindingKey => nameof(Priestly1In9ArtifactBiasWeightedRandom);
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "3500"),
    };
}
