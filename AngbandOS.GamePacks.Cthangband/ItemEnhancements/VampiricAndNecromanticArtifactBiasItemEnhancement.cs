namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class VampiricAndNecromanticArtifactBiasItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Vampiric => true;
    public override string? ArtifactBiasWeightedRandomBindingKey => nameof(Necromantic1In1ArtifactBiasWeightedRandom);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "13000"),
    };
}
