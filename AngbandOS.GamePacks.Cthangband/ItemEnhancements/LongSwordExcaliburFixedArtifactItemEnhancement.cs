namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LongSwordExcaliburFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BoolAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(RegenAttribute), "true"),
    };

    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(BrandColdAttribute), "true"),
        (nameof(FreeActAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResColdAttribute), "true"),
        (nameof(ResLightAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
        (nameof(SlayDemonAttribute), "true"),
        (nameof(SlayEvilAttribute), "true"),
        (nameof(SlayTrollAttribute), "true"),
        (nameof(SlayUndeadAttribute), "true"),
        (nameof(SlowDigestAttribute), "true"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.BallOfCold100r2Every300DirectionalActivation);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ToDamageAttribute), "25"),
        (nameof(MeleeToHitAttribute), "22"),
        (nameof(DamageDiceAttribute), "2"),
        (nameof(ValueAttribute), "300000"),
        (nameof(SpeedAttribute), "10"),
        (nameof(RadiusAttribute), "3"),
    };
    public override string FriendlyName => "'Excalibur'";
}
