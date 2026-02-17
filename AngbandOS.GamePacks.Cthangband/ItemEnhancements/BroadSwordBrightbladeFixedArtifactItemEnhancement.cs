namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BroadSwordBrightbladeFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(RadiusAttribute), "3"),
        (nameof(ValueAttribute), "40000"),
        (nameof(SearchAttribute), "1"),
        (nameof(MeleeToHitAttribute), "10"),
        (nameof(ToDamageAttribute), "15"),
    };
    public override bool? BrandFire => true;
    public override string FriendlyName => "'Brightblade'";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResFire => true;
    public override bool? ResLight => true;
    public override bool? ShowMods => true;
    public override bool? SlayEvil => true;
    public override bool? SlayOrc => true;
    public override bool? SlowDigest => true;
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
