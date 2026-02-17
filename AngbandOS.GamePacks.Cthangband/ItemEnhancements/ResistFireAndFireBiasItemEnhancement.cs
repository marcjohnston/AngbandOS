namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ResistFireAndFireBiasItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ResFire => true;
    public override string? ArtifactBiasWeightedRandomBindingKey => nameof(Fire1In1ArtifactBiasWeightedRandom);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "1250"),
    };
}
