namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class IronCrownOfMiseryFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ValuelessAttribute), "true"),
        (nameof(FreeActAttribute), "true"),
        (nameof(HideTypeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
        (nameof(TelepathyAttribute), "true"),
        (nameof(FeatherAttribute), "true"),
        (nameof(HoldLifeAttribute), "true"),
        (nameof(RegenAttribute), "true"),
        (nameof(SlowDigestAttribute), "true"),
    };
    public override (string AttributeName, string BooleanExpression)[]? BoolAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(IsCursedAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(ValueAttribute), "112400"),
        (nameof(AttacksAttribute), "25"),
        (nameof(RadiusAttribute), "3"),
        (nameof(DexterityAttribute), "-25"),
        (nameof(ConstitutionAttribute), "-25"),
        (nameof(StrengthAttribute), "-25"),
    };
    public override string FriendlyName => "of Misery";
    public override ColorEnum? Color => ColorEnum.Grey;
}
