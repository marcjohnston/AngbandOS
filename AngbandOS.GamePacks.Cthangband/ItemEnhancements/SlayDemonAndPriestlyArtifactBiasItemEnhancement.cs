namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SlayDemonAndPriestlyArtifactBiasItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? SlayDemon => true;
    public override string? ArtifactBiasWeightedRandomBindingKey => nameof(Priestly1In9ArtifactBiasWeightedRandom);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "3500"),
    };
}
