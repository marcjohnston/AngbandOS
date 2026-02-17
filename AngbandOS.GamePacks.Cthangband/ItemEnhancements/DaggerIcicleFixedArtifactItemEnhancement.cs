namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DaggerIcicleFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(BrandColdAttribute), "true"),
        (nameof(BrandPoisAttribute), "true"),
        (nameof(HideTypeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(RegenAttribute), "true"),
        (nameof(ResColdAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
        (nameof(SlowDigestAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(DexterityAttribute), "2"),
        (nameof(AttacksAttribute), "2"),
        (nameof(SpeedAttribute), "2"),
        (nameof(ValueAttribute), "50000"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(MeleeToHitAttribute), "6"),
        (nameof(ToDamageAttribute), "9"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.BallOfCold48r2Every5p1d5DirectionalActivation);
    public override string FriendlyName => "'Icicle'";
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
