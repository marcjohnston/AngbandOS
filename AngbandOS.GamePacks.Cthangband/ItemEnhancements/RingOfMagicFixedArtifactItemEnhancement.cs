namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RingOfMagicFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
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
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResPois => true;
    public override bool? SeeInvis => true;
}
