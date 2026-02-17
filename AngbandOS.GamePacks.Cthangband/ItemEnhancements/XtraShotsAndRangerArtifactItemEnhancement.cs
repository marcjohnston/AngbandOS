namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class XtraShotsAndRangerArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? XtraShots => true;
    public override string? ArtifactBiasWeightedRandomBindingKey => nameof(Ranger1In9ArtifactBiasWeightedRandom);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "10000"),
    };
}
