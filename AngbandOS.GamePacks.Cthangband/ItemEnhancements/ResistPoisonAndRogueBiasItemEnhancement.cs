namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ResistPoisonAndRogueBiasItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ResPois => true;
    public override string? ArtifactBiasWeightedRandomBindingKey => nameof(Rogue1In1ArtifactBiasWeightedRandom);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "2500"),
    };
}
