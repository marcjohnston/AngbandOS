namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DaggerOfAssassinFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(BrandPoisAttribute), "true"),
        (nameof(FreeActAttribute), "true"),
        (nameof(HideTypeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResDarkAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
        (nameof(SlayEvilAttribute), "true"),
        (nameof(SlayOrcAttribute), "true"),
        (nameof(SlayTrollAttribute), "true"),
        (nameof(SustDexAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(DexterityAttribute), "4"),
        (nameof(SearchAttribute), "4"),
        (nameof(StealthAttribute), "4"),
        (nameof(ValueAttribute), "125000"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(AttacksAttribute), "5"),
        (nameof(MeleeToHitAttribute), "10"),
        (nameof(ToDamageAttribute), "15"),
    };
    public override string FriendlyName => "of Assassin";
}
