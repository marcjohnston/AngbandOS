namespace AngbandOS.GamePacks.Cthangband;

public class StarEssenceOfPolarisFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(ValueAttribute), "10000"),
        (nameof(GlowRadiusAttribute), "1"),
        (nameof(SearchAttribute), "1"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.IlluminationEvery1d10p10DirectionalActivation);
    public override string FriendlyName => "of Polaris";
}
