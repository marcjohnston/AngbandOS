namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GoldenCrownOfTheSunFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BoolAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(RegenAttribute), "true"),
    };

    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HideTypeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResBlindAttribute), "true"),
        (nameof(ResChaosAttribute), "true"),
        (nameof(ResColdAttribute), "true"),
        (nameof(ResElecAttribute), "true"),
        (nameof(ResFireAttribute), "true"),
        (nameof(ResLightAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
        (nameof(FeatherAttribute), "true"),
        (nameof(FreeActAttribute), "true"),
        (nameof(HoldLifeAttribute), "true"),
        (nameof(SlowDigestAttribute), "true"),
        (nameof(TelepathyAttribute), "true"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.Heal700Every25Activation);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(StrengthAttribute), "3"),
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(AttacksAttribute), "15"),
        (nameof(ValueAttribute), "125000"),
        (nameof(WisdomAttribute), "3"),
        (nameof(SpeedAttribute), "3"),
        (nameof(ConstitutionAttribute), "3"),
        (nameof(RadiusAttribute), "3"),
    };
    public override string FriendlyName => "of the Sun";
    public override ColorEnum? Color => ColorEnum.Yellow;
}
