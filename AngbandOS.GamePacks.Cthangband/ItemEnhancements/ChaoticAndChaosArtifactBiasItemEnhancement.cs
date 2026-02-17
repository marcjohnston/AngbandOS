namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ChaoticAndChaosArtifactBiasItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Chaotic => true;
    public override string? ArtifactBiasWeightedRandomBindingKey => nameof(Chaos1In1ArtifactBiasWeightedRandom);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "10000"),
    };
}
