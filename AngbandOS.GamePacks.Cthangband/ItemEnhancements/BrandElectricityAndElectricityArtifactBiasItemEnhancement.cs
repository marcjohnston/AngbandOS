namespace AngbandOS.GamePacks.Cthangband;

public class BrandElectricityAndElectricityArtifactBiasItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(BrandElecAttribute), "true"),
    };
    public override string? ArtifactBiasWeightedRandomBindingKey => nameof(Electricity1In1ArtifactBiasWeightedRandom);
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "7500"),
    };
}
