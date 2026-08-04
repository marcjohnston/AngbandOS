namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SheathOfFireAndFireBiasItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ShFireAttribute), "true"),
    };
    public override string? ArtifactBiasWeightedRandomBindingKey => nameof(Fire1In1ArtifactBiasWeightedRandom);
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "5000"),
    };
}
