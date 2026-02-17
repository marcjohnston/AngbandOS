namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BrandElectricityAndElectricityArtifactBiasItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? BrandElec => true;
    public override string? ArtifactBiasWeightedRandomBindingKey => nameof(Electricity1In1ArtifactBiasWeightedRandom);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "7500"),
    };
}
