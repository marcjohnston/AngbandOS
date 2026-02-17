namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DaggerOfThothFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(BrandPoisAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResDisenAttribute), "true"),
        (nameof(ResPoisAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
        (nameof(SlayOrcAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(ValueAttribute), "35000"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(MeleeToHitAttribute), "4"),
        (nameof(ToDamageAttribute), "3"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.StinkingCloud12Every1d4p4DirectionalActivation);
    public override string FriendlyName => "of Thoth";
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
