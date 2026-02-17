namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LongSwordVorpalBladeFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
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
    public override bool? FreeAct => true;
    public override string FriendlyName => "'Vorpal Blade'";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? Regen => true;
    public override bool? SeeInvis => true;
    public override bool? SlayEvil => true;
    public override bool? SlowDigest => true;
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
