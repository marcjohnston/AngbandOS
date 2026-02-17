namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LongSwordVorpalBladeFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(FreeActAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(RegenAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
        (nameof(SlayEvilAttribute), "true"),
        (nameof(SlowDigestAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
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
        (nameof(DexterityAttribute), "2"),
        (nameof(RadiusAttribute), "3"),
        (nameof(StrengthAttribute), "2"),
    };
    public override string FriendlyName => "'Vorpal Blade'";
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
