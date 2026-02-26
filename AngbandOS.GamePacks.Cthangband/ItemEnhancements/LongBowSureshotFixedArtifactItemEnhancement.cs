namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LongBowSureshotFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HideTypeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResDisenAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
        (nameof(XtraShotsAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(ToDamageAttribute), "22"),
        (nameof(MeleeToHitAttribute), "20"),
        (nameof(ValueAttribute), "35000"),
        (nameof(StealthAttribute), "3"),
        (nameof(DexterityAttribute), "3"),
    };
    public override string FriendlyName => "'Sureshot'";
    public override ColorEnum? Color => ColorEnum.BrightBrown;
}
