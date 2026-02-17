namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ResistElectricityAndElectricityBiasItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ResElec => true;
    public override string? ArtifactBiasWeightedRandomBindingKey => nameof(Electricity1In1ArtifactBiasWeightedRandom);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "1250"),
    };
}
