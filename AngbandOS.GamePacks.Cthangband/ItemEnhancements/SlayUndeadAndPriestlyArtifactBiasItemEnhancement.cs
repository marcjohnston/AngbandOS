namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SlayUndeadAndPriestlyArtifactBiasItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? SlayUndead => true;
    public override string? ArtifactBiasWeightedRandomBindingKey => nameof(Priestly1In9ArtifactBiasWeightedRandom);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "3500"),
    };
}
