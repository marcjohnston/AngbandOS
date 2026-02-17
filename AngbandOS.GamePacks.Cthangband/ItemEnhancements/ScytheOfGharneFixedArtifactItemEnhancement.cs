namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ScytheOfGharneFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(BrandColdAttribute), "true"),
        (nameof(BrandFireAttribute), "true"),
        (nameof(FreeActAttribute), "true"),
        (nameof(HideTypeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResColdAttribute), "true"),
        (nameof(ResFireAttribute), "true"),
        (nameof(ResLightAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(ToDamageAttribute), "8"),
        (nameof(MeleeToHitAttribute), "8"),
        (nameof(AttacksAttribute), "10"),
        (nameof(ValueAttribute), "18000"),
        (nameof(DexterityAttribute), "3"),
        (nameof(CharismaAttribute), "3"),
        (nameof(RadiusAttribute), "3"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.WordOfRecallEvery200DirectionalActivation);
    public override string FriendlyName => "of G'harne";
    public override ColorEnum? Color => ColorEnum.Grey;
}
