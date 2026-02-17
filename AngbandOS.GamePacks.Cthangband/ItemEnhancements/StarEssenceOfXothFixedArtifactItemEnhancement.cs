namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class StarEssenceOfXothFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HoldLifeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(ValueAttribute), "32500"),
        (nameof(RadiusAttribute), "1"),
        (nameof(SpeedAttribute), "1"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.MagicMappingAndIlluminationEvery1d50p50DirectionalActivation);
    public override string FriendlyName => "of Xoth";
    public override ColorEnum? Color => ColorEnum.Yellow;
}
