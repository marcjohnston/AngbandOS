namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class StarEssenceOfPolarisFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(ValueAttribute), "10000"),
        (nameof(RadiusAttribute), "1"),
        (nameof(SearchAttribute), "1"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.IlluminationEvery1d10p10DirectionalActivation);
    public override string FriendlyName => "of Polaris";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override ColorEnum? Color => ColorEnum.Yellow;
}
