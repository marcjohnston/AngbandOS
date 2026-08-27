namespace AngbandOS.GamePacks.Cthangband;

public class AugmentedChainMailOfTheOgreLordsFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HideTypeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResAcidAttribute), "true"),
        (nameof(ResConfAttribute), "true"),
        (nameof(ResPoisAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(BonusConstitutionAttribute), "3"),
        (nameof(AttacksAttribute), "20"),
        (nameof(MeleeToHitAttribute), "-2"),
        (nameof(ValueAttribute), "40000"),
        (nameof(BonusIntelligenceAttribute), "3"),
        (nameof(BonusWisdomAttribute), "3"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.DestroyDoorsEvery10Activation);
    public override string FriendlyName => "of the Ogre Lords";
}
