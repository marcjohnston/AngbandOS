namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ResistPoisonAndNecromanticBiasItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ResPois => true;
    public override string? ArtifactBiasWeightedRandomBindingKey => nameof(Necromantic1In1ArtifactBiasWeightedRandom);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "2500"),
    };
}
