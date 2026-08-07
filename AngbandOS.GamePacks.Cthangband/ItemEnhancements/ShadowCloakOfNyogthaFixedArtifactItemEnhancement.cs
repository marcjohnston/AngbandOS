namespace AngbandOS.GamePacks.Cthangband;

public class ShadowCloakOfNyogthaFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HideTypeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResAcidAttribute), "true"),
        (nameof(ResColdAttribute), "true"),
        (nameof(ResFireAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(AttacksAttribute), "20"),
        (nameof(ValueAttribute), "55000"),
        (nameof(BonusWisdomAttribute), "2"),
        (nameof(StealthAttribute), "2"),
        (nameof(SpeedAttribute), "2"),
        (nameof(BonusIntelligenceAttribute), "2"),
        (nameof(BonusCharismaAttribute), "2"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.RestoreLifeLevelsEvery450DirectionalActivation);
    public override string FriendlyName => "of Nyogtha";
}
