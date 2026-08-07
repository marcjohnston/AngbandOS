namespace AngbandOS.GamePacks.Cthangband;

public class TwoHandedFlailThunderfistFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(BrandElecAttribute), "true"),
        (nameof(BrandFireAttribute), "true"),
        (nameof(HideTypeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResDarkAttribute), "true"),
        (nameof(ResElecAttribute), "true"),
        (nameof(ResFireAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
        (nameof(SlayAnimalAttribute), "true"),
        (nameof(SlayOrcAttribute), "true"),
        (nameof(SlayTrollAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ToDamageAttribute), "18"),
        (nameof(MeleeToHitAttribute), "5"),
        (nameof(ValueAttribute), "160000"),
        (nameof(WeightAttribute), "20"),
        (nameof(GlowRadiusAttribute), "3"),
        (nameof(BonusStrengthAttribute), "4"),
    };
    public override string FriendlyName => "'Thunderfist'";
}
