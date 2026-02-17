namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ResistConfusionAndChaosBiasItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ResConf => true;
    public override string? ArtifactBiasWeightedRandomBindingKey => nameof(Chaos1In1ArtifactBiasWeightedRandom);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "2000"),
    };
}
