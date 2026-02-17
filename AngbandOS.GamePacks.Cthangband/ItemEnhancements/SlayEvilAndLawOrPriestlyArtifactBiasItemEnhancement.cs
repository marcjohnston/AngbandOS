namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SlayEvilAndLawOrPriestlyArtifactBiasItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? SlayEvil => true;
    public override string? ArtifactBiasWeightedRandomBindingKey => nameof(Law1In2OrPriestly1In9ArtifactBiasWeightedRandom);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "4500"),
    };
}
