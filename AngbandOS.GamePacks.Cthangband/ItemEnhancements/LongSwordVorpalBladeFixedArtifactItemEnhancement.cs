namespace AngbandOS.GamePacks.Cthangband;

public class LongSwordVorpalBladeFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(RegenAttribute), "true"),
        (nameof(FreeActAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
        (nameof(SlayEvilAttribute), "true"),
        (nameof(SlowDigestAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ToDamageAttribute), "32"),
        (nameof(MeleeToHitAttribute), "32"),
        (nameof(DamageDiceAttribute), "3"),
        (nameof(ValueAttribute), "250000"),
        (nameof(WeightAttribute), "20"),
        (nameof(VorpalExtraAttacks1InChanceAttribute), "2"),
        (nameof(Vorpal1InChanceAttribute), "3"),
        (nameof(SpeedAttribute), "2"),
        (nameof(BonusDexterityAttribute), "2"),
        (nameof(GlowRadiusAttribute), "3"),
        (nameof(BonusStrengthAttribute), "2"),
    };
    public override string FriendlyName => "'Vorpal Blade'";
}
