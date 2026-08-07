namespace AngbandOS.GamePacks.Cthangband;

public class LucerneHammerJusticeFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(RegenAttribute), "true"),
        (nameof(BrandColdAttribute), "true"),
        (nameof(HideTypeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResColdAttribute), "true"),
        (nameof(ResLightAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
        (nameof(SlayOrcAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(GlowRadiusAttribute), "3"),
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(InfraVisionAttribute), "4"),
        (nameof(ToDamageAttribute), "6"),
        (nameof(MeleeToHitAttribute), "10"),
        (nameof(AttacksAttribute), "8"),
        (nameof(ValueAttribute), "30000"),
        (nameof(BonusWisdomAttribute), "4"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.DrainLife90Every70DirectionalActivation);
    public override string FriendlyName => "'Justice'";
}
