namespace AngbandOS.GamePacks.Cthangband;

public class LongSwordOfEverflameFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(BrandFireAttribute), "true"),
        (nameof(FreeActAttribute), "true"),
        (nameof(HideTypeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResFireAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
        (nameof(SlayEvilAttribute), "true"),
        (nameof(SlayOrcAttribute), "true"),
        (nameof(SlayTrollAttribute), "true"),
        (nameof(SustDexAttribute), "true"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.BallOfFire72r2Every400DirectionalActivation);
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ToDamageAttribute), "15"),
        (nameof(MeleeToHitAttribute), "10"),
        (nameof(AttacksAttribute), "5"),
        (nameof(ValueAttribute), "80000"),
        (nameof(GlowRadiusAttribute), "3"),
        (nameof(BonusStrengthAttribute), "4"),
    };
    public override string FriendlyName => "of Everflame";
}
