namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ResistPoisonAndRogueBiasItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResPoisAttribute), "true"),
    };
    public override string? ArtifactBiasWeightedRandomBindingKey => nameof(Rogue1In1ArtifactBiasWeightedRandom);
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "2500"),
    };
}
