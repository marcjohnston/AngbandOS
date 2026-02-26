namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SpearGaeBulgFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(BrandColdAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResColdAttribute), "true"),
        (nameof(ResDarkAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
        (nameof(SlayUndeadAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(ToDamageAttribute), "13"),
        (nameof(MeleeToHitAttribute), "11"),
        (nameof(ValueAttribute), "30000"),
        (nameof(StealthAttribute), "3"),
        (nameof(SpeedAttribute), "3"),
        (nameof(InfravisionAttribute), "3"),
    };
    public override string FriendlyName => "'Gae Bulg'";
    public override ColorEnum? Color => ColorEnum.Grey;
}
