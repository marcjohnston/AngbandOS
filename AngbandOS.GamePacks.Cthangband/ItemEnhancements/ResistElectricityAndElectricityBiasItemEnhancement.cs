namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ResistElectricityAndElectricityBiasItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResElecAttribute), "true"),
    };
    public override string? ArtifactBiasWeightedRandomBindingKey => nameof(Electricity1In1ArtifactBiasWeightedRandom);
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "1250"),
    };
}
