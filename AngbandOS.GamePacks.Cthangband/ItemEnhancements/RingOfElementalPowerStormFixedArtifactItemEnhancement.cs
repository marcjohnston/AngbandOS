namespace AngbandOS.GamePacks.Cthangband;

public class RingOfElementalPowerStormFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
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
        (nameof(ImElecAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
        (nameof(SlowDigestAttribute), "true"),
        (nameof(SustDexAttribute), "true"),
        (nameof(SustIntAttribute), "true"),
        (nameof(SustStrAttribute), "true"),
        (nameof(SustWisAttribute), "true"),
        (nameof(TelepathyAttribute), "true"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.LargeLightningBall250Every425p1d425DirectionalActivation);
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ToDamageAttribute), "12"),
        (nameof(MeleeToHitAttribute), "12"),
        (nameof(DiceSidesAttribute), "1"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(ValueAttribute), "300000"),
        (nameof(GlowRadiusAttribute), "3"),
        (nameof(WisdomAttribute), "3"),
        (nameof(SpeedAttribute), "3"),
        (nameof(IntelligenceAttribute), "3"),
        (nameof(DexterityAttribute), "3"),
        (nameof(ConstitutionAttribute), "3"),
        (nameof(CharismaAttribute), "3"),
        (nameof(StrengthAttribute), "3"),
    };
    public override string FriendlyName => "of Elemental Power (Storm)";
}
