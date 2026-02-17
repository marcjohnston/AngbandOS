namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BrandAcidAndAcidArtifactBiasItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? BrandAcid => true;
    public override string? ArtifactBiasWeightedRandomBindingKey => nameof(Acid1In1ArtifactBiasWeightedRandom);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "7500"),
    };
}
