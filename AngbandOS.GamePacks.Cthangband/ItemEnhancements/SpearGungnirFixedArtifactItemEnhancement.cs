namespace AngbandOS.GamePacks.Cthangband;

public class SpearGungnirFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(BlessedAttribute), "true"),
        (nameof(BrandElecAttribute), "true"),
        (nameof(BrandFireAttribute), "true"),
        (nameof(FreeActAttribute), "true"),
        (nameof(HideTypeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResElecAttribute), "true"),
        (nameof(ResFireAttribute), "true"),
        (nameof(ResLightAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
        (nameof(SlayGiantAttribute), "true"),
        (nameof(SlayOrcAttribute), "true"),
        (nameof(SlayTrollAttribute), "true"),
        (nameof(SlowDigestAttribute), "true"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.BallOfLightning100r3Every500DirectionalActivation);
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ToDamageAttribute), "25"),
        (nameof(MeleeToHitAttribute), "15"),
        (nameof(AttacksAttribute), "5"),
        (nameof(DamageDiceAttribute), "3"),
        (nameof(ValueAttribute), "180000"),
        (nameof(BonusWisdomAttribute), "4"),
        (nameof(BonusIntelligenceAttribute), "4"),
        (nameof(GlowRadiusAttribute), "3"),
    };
    public override string FriendlyName => "'Gungnir'";
}
