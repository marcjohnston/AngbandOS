namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RingOfElementalPowerIceFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(FeatherAttribute), "true"),
        (nameof(FreeActAttribute), "true"),
        (nameof(HideTypeAttribute), "true"),
        (nameof(HoldLifeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ImColdAttribute), "true"),
        (nameof(RegenAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
        (nameof(SustIntAttribute), "true"),
        (nameof(SustWisAttribute), "true"),
        (nameof(SlowDigestAttribute), "true"),
        (nameof(TelepathyAttribute), "true"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.LargeFrostBall200Every325p1d325DirectionalActivation);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ToDamageAttribute), "11"),
        (nameof(MeleeToHitAttribute), "11"),
        (nameof(DiceSidesAttribute), "1"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(ValueAttribute), "200000"),
        (nameof(RadiusAttribute), "3"),
        (nameof(WisdomAttribute), "2"),
        (nameof(SpeedAttribute), "2"),
        (nameof(DexterityAttribute), "2"),
        (nameof(IntelligenceAttribute), "2"),
        (nameof(ConstitutionAttribute), "2"),
        (nameof(CharismaAttribute), "2"),
        (nameof(StrengthAttribute), "2"),
    };
    public override string FriendlyName => "of Elemental Power (Ice)";
}
