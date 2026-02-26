namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class StarEssenceOfPolarisFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(ValueAttribute), "10000"),
        (nameof(RadiusAttribute), "1"),
        (nameof(SearchAttribute), "1"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.IlluminationEvery1d10p10DirectionalActivation);
    public override string FriendlyName => "of Polaris";
}
