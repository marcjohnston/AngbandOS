namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class StarEssenceOfXothFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(ValueAttribute), "32500"),
        (nameof(RadiusAttribute), "1"),
        (nameof(SpeedAttribute), "1"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.MagicMappingAndIlluminationEvery1d50p50DirectionalActivation);
    public override string FriendlyName => "of Xoth";
    public override bool? HoldLife => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? SeeInvis => true;
    public override ColorEnum? Color => ColorEnum.Yellow;
}
