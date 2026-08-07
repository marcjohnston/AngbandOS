namespace AngbandOS.GamePacks.Cthangband;

public class LongSwordOfKarakalFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(RegenAttribute), "true"),
        (nameof(BrandElecAttribute), "true"),
        (nameof(ChaoticAttribute), "true"),
        (nameof(FreeActAttribute), "true"),
        (nameof(HideTypeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResDarkAttribute), "true"),
        (nameof(ResDisenAttribute), "true"),
        (nameof(ResElecAttribute), "true"),
        (nameof(ResFearAttribute), "true"),
        (nameof(ResLightAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
        (nameof(SlayDemonAttribute), "true"),
        (nameof(SlayEvilAttribute), "true"),
        (nameof(SlowDigestAttribute), "true"),
        (nameof(SustConAttribute), "true"),
        (nameof(SustIntAttribute), "true"),
        (nameof(SustStrAttribute), "true"),
        (nameof(SustWisAttribute), "true"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.GetawayEvery35Activation);
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ToDamageAttribute), "12"),
        (nameof(MeleeToHitAttribute), "8"),
        (nameof(ValueAttribute), "150000"),
        (nameof(SpeedAttribute), "2"),
        (nameof(BonusConstitutionAttribute), "2"),
        (nameof(AttacksAttribute), "2"),
        (nameof(GlowRadiusAttribute), "3"),
        (nameof(BonusStrengthAttribute), "2"),
    };
    public override string FriendlyName => "of Karakal";
}
