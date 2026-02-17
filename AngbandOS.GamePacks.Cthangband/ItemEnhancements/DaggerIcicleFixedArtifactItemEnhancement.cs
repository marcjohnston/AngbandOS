namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DaggerIcicleFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(DexterityAttribute), "2"),
        (nameof(AttacksAttribute), "2"),
        (nameof(SpeedAttribute), "2"),
        (nameof(ValueAttribute), "50000"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(MeleeToHitAttribute), "6"),
        (nameof(ToDamageAttribute), "9"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.BallOfCold48r2Every5p1d5DirectionalActivation);
    public override bool? BrandCold => true;
    public override bool? BrandPois => true;
    public override string FriendlyName => "'Icicle'";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? Regen => true;
    public override bool? ResCold => true;
    public override bool? SeeInvis => true;
    public override bool? ShowMods => true;
    public override bool? SlowDigest => true;
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
