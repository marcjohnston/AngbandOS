namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RingOfMagicFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
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
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ValueAttribute), "75000"),
        (nameof(WisdomAttribute), "1"),
        (nameof(StealthAttribute), "1"),
        (nameof(SearchAttribute), "1"),
        (nameof(IntelligenceAttribute), "1"),
        (nameof(DexterityAttribute), "1"),
        (nameof(ConstitutionAttribute), "1"),
        (nameof(CharismaAttribute), "1"),
        (nameof(StrengthAttribute), "1"),
    };
    public override string FriendlyName => "of Magic";
}
