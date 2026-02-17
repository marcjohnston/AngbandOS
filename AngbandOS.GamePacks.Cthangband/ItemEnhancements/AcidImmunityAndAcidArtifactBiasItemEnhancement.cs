namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AcidImmunityAndAcidArtifactBiasItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ImAcidAttribute), "true"),
    };
    public override string? ArtifactBiasWeightedRandomBindingKey => nameof(Acid1In1ArtifactBiasWeightedRandom);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "10000"),
    };
}
