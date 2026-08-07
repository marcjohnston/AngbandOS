namespace AngbandOS.GamePacks.Cthangband;

public class IronHelmSkullkeeperFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HideTypeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResBlindAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.DetectionEvery55p1d55Activation);
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(AttacksAttribute), "10"),
        (nameof(ValueAttribute), "100000"),
        (nameof(BonusWisdomAttribute), "2"),
        (nameof(BonusIntelligenceAttribute), "2"),
    };
    public override string FriendlyName => "'Skullkeeper'";
}
