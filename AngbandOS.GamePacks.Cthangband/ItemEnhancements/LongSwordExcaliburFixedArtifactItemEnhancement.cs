namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LongSwordExcaliburFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.BallOfCold100r2Every300DirectionalActivation);
    public override bool? BrandCold => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ToDamageAttribute), "25"),
        (nameof(MeleeToHitAttribute), "22"),
        (nameof(DamageDiceAttribute), "2"),
        (nameof(ValueAttribute), "300000"),
        (nameof(SpeedAttribute), "10"),
        (nameof(RadiusAttribute), "3"),
    };
    public override bool? FreeAct => true;
    public override string FriendlyName => "'Excalibur'";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? Regen => true;
    public override bool? ResCold => true;
    public override bool? ResLight => true;
    public override bool? SeeInvis => true;
    public override bool? ShowMods => true;
    public override bool? SlayDemon => true;
    public override bool? SlayEvil => true;
    public override bool? SlayTroll => true;
    public override bool? SlayUndead => true;
    public override bool? SlowDigest => true;
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
