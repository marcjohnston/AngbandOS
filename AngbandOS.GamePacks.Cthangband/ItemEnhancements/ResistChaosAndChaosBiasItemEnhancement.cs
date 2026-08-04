namespace AngbandOS.GamePacks.Cthangband;

public class ResistChaosAndChaosBiasItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResChaosAttribute), "true"),
        (nameof(ResConfAttribute), "true"),
    };
    public override string? ArtifactBiasWeightedRandomBindingKey => nameof(Chaos1In1ArtifactBiasWeightedRandom);
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "2000"),
    };
}
