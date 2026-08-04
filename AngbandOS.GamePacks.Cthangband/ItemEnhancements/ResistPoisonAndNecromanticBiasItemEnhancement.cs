namespace AngbandOS.GamePacks.Cthangband;

public class ResistPoisonAndNecromanticBiasItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResPoisAttribute), "true"),
    };
    public override string? ArtifactBiasWeightedRandomBindingKey => nameof(Necromantic1In1ArtifactBiasWeightedRandom);
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "2500"),
    };
}
