namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ResistAcidAndAcidBiasItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ResAcid => true;
    public override string? ArtifactBiasWeightedRandomBindingKey => nameof(Acid1In1ArtifactBiasWeightedRandom);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "1250"),
    };
}
