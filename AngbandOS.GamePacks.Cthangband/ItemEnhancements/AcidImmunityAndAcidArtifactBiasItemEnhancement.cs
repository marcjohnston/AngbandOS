namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AcidImmunityAndAcidArtifactBiasItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ImAcid => true;
    public override string? ArtifactBiasWeightedRandomBindingKey => nameof(Acid1In1ArtifactBiasWeightedRandom);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "10000"),
    };
}
