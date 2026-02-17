namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BrandPoisonAndPoisonNecromanticOrRogueArtifactBiasItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? BrandPois => true;
    public override string? ArtifactBiasWeightedRandomBindingKey => nameof(Poison1In3OrNecromantic1In6OrRogue1ArtifactBiasWeightedRandom);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "7500"),
    };
}
