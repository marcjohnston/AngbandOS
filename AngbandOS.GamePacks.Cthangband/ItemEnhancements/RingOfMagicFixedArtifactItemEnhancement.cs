namespace AngbandOS.GamePacks.Cthangband;

public class RingOfMagicFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HideTypeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResPoisAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.DrainLife100Every100p1d100DirectionalActivation);
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ValueAttribute), "75000"),
        (nameof(BonusWisdomAttribute), "1"),
        (nameof(StealthAttribute), "1"),
        (nameof(SearchAttribute), "5"),
        (nameof(BonusIntelligenceAttribute), "1"),
        (nameof(BonusDexterityAttribute), "1"),
        (nameof(BonusConstitutionAttribute), "1"),
        (nameof(BonusCharismaAttribute), "1"),
        (nameof(BonusStrengthAttribute), "1"),
    };
    public override string FriendlyName => "of Magic";
}
