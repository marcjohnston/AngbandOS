namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RingOfSetFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(AggravateAttribute), "true"),
        (nameof(DrainExpAttribute), "true"),
        (nameof(DreadCurseAttribute), "true"),
        (nameof(HideTypeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ImAcidAttribute), "true"),
        (nameof(ImColdAttribute), "true"),
        (nameof(ImElecAttribute), "true"),
        (nameof(ImFireAttribute), "true"),
        (nameof(PermaCurseAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
        (nameof(SustChaAttribute), "true"),
        (nameof(SustConAttribute), "true"),
        (nameof(SustDexAttribute), "true"),
        (nameof(SustIntAttribute), "true"),
        (nameof(SustStrAttribute), "true"),
        (nameof(SustWisAttribute), "true"),
        (nameof(FeatherAttribute), "true"),
        (nameof(FreeActAttribute), "true"),
        (nameof(HoldLifeAttribute), "true"),
        (nameof(SlowDigestAttribute), "true"),
        (nameof(TelepathyAttribute), "true"),
    };
    public override (string AttributeName, string BooleanExpression)[]? BoolAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(RegenAttribute), "true"),
        (nameof(HeavyCurseAttribute), "true"),
        (nameof(IsCursedAttribute), "true"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.BizarreThingsEvery1d450p450DirectionalActivation);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ToDamageAttribute), "15"),
        (nameof(MeleeToHitAttribute), "15"),
        (nameof(DiceSidesAttribute), "1"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(ValueAttribute), "5000000"),
        (nameof(RadiusAttribute), "3"),
        (nameof(WisdomAttribute), "5"),
        (nameof(SpeedAttribute), "5"),
        (nameof(IntelligenceAttribute), "5"),
        (nameof(DexterityAttribute), "5"),
        (nameof(ConstitutionAttribute), "5"),
        (nameof(CharismaAttribute), "5"),
        (nameof(StrengthAttribute), "5"),
    };
    public override string FriendlyName => "of Set";
    public override ColorEnum? Color => ColorEnum.Yellow;
}
