namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class IronHelmTerrorMaskFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(FreeActAttribute), "true"),
        (nameof(HideTypeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ImColdAttribute), "true"),
        (nameof(NoMagicAttribute), "true"),
        (nameof(ResAcidAttribute), "true"),
        (nameof(ResColdAttribute), "true"),
        (nameof(ResDisenAttribute), "true"),
        (nameof(ResFearAttribute), "true"),
        (nameof(ResPoisAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
        (nameof(TeleportAttribute), "true"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.Terror40xEvery3xp10Activation);
    public override string FriendlyName => "'Terror Mask'";
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(IntelligenceAttribute), "-1"),
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(SearchAttribute), "-1"),
        (nameof(ToDamageAttribute), "25"),
        (nameof(MeleeToHitAttribute), "25"),
        (nameof(AttacksAttribute), "10"),
        (nameof(ValueAttribute), "40000"),
        (nameof(WisdomAttribute), "-1"),
    };
    public override ColorEnum? Color => ColorEnum.Grey;
}
