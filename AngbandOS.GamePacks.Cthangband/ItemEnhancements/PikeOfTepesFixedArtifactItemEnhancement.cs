namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PikeOfTepesFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(BrandColdAttribute), "true"),
        (nameof(BrandFireAttribute), "true"),
        (nameof(HideTypeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResColdAttribute), "true"),
        (nameof(ResFireAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
        (nameof(SlayDemonAttribute), "true"),
        (nameof(SlayGiantAttribute), "true"),
        (nameof(SlayTrollAttribute), "true"),
        (nameof(SlowDigestAttribute), "true"),
        (nameof(SustIntAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(ToDamageAttribute), "12"),
        (nameof(MeleeToHitAttribute), "10"),
        (nameof(AttacksAttribute), "10"),
        (nameof(ValueAttribute), "32000"),
        (nameof(IntelligenceAttribute), "2"),
        (nameof(RadiusAttribute), "3"),
    };
    public override string FriendlyName => "of Tepes";
}
