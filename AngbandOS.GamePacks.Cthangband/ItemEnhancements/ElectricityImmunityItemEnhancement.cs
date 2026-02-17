namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ElectricityImmunityItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ImElec => true;
    public override string? ArtifactBiasWeightedRandomBindingKey => nameof(Electricity1In1ArtifactBiasWeightedRandom);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "10000"),
    };
}
