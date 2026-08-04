namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BrandPoisonAndPoisonNecromanticOrRogueArtifactBiasItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(BrandPoisAttribute), "true"),
    };
    public override string? ArtifactBiasWeightedRandomBindingKey => nameof(Poison1In3OrNecromantic1In6OrRogue1ArtifactBiasWeightedRandom);
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "7500"),
    };
}
