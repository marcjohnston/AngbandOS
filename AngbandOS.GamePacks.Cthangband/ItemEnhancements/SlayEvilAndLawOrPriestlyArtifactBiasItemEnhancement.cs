namespace AngbandOS.GamePacks.Cthangband;

public class SlayEvilAndLawOrPriestlyArtifactBiasItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(SlayEvilAttribute), "true"),
    };
    public override string? ArtifactBiasWeightedRandomBindingKey => nameof(Law1In2OrPriestly1In9ArtifactBiasWeightedRandom);
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "4500"),
    };
}
