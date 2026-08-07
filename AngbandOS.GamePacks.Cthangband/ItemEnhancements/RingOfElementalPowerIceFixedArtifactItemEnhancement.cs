namespace AngbandOS.GamePacks.Cthangband;

public class RingOfElementalPowerIceFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(RegenAttribute), "true"),
        (nameof(FeatherAttribute), "true"),
        (nameof(FreeActAttribute), "true"),
        (nameof(HideTypeAttribute), "true"),
        (nameof(HoldLifeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ImColdAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
        (nameof(SustIntAttribute), "true"),
        (nameof(SustWisAttribute), "true"),
        (nameof(SlowDigestAttribute), "true"),
        (nameof(TelepathyAttribute), "true"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.LargeFrostBall200Every325p1d325DirectionalActivation);
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ToDamageAttribute), "11"),
        (nameof(MeleeToHitAttribute), "11"),
        (nameof(DiceSidesAttribute), "1"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(ValueAttribute), "200000"),
        (nameof(GlowRadiusAttribute), "3"),
        (nameof(BonusWisdomAttribute), "2"),
        (nameof(SpeedAttribute), "2"),
        (nameof(BonusDexterityAttribute), "2"),
        (nameof(BonusIntelligenceAttribute), "2"),
        (nameof(BonusConstitutionAttribute), "2"),
        (nameof(BonusCharismaAttribute), "2"),
        (nameof(BonusStrengthAttribute), "2"),
    };
    public override string FriendlyName => "of Elemental Power (Ice)";
}
