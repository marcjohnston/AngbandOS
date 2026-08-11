namespace AngbandOS.GamePacks.Cthangband;

public class LeadCrownOfTheUniverseFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HeavyCurseAttribute), "true"),
        (nameof(IsCursedAttribute), "true"),
        (nameof(HideTypeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(NoTeleAttribute), "true"),
        (nameof(PermaCurseAttribute), "true"),
        (nameof(ResAcidAttribute), "true"),
        (nameof(ResColdAttribute), "true"),
        (nameof(ResConfAttribute), "true"),
        (nameof(ResDarkAttribute), "true"),
        (nameof(ResElecAttribute), "true"),
        (nameof(ResFireAttribute), "true"),
        (nameof(ResLightAttribute), "true"),
        (nameof(ResNexusAttribute), "true"),
        (nameof(ResPoisAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
        (nameof(TelepathyAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ValueAttribute), "10000000"),
        (nameof(BonusWisdomAttribute), "125"),
        (nameof(InfraVisionAttribute), "125"),
        (nameof(BonusIntelligenceAttribute), "125"),
        (nameof(BonusDexterityAttribute), "125"),
        (nameof(BonusConstitutionAttribute), "125"),
        (nameof(BonusCharismaAttribute), "125"),
        (nameof(GlowRadiusAttribute), "3"),
        (nameof(BonusStrengthAttribute), "125"),
    };
    public override string FriendlyName => "of the Universe";
}
