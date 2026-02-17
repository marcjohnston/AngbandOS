namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PikeOfTepesFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
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
    public override bool? BrandCold => true;
    public override bool? BrandFire => true;
    public override string FriendlyName => "of Tepes";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResCold => true;
    public override bool? ResFire => true;
    public override bool? ShowMods => true;
    public override bool? SlayDemon => true;
    public override bool? SlayGiant => true;
    public override bool? SlayTroll => true;
    public override bool? SlowDigest => true;
    public override bool? SustInt => true;
    public override ColorEnum? Color => ColorEnum.Grey;
}
