namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BroadSwordBrightbladeFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    public override bool BrandFire => true;
    public override string FriendlyName => "'Brightblade'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;

    /// <summary>
    /// Returns a value of 3 to add to the radius of light for a broad sword which provides no light.
    /// </summary>
    public override int Radius => 3;

    public override string? BonusSearchRollExpression => "1";
    public override bool ResFire => true;
    public override bool ResLight => true;
    public override bool ShowMods => true;
    public override bool SlayEvil => true;
    public override bool SlayOrc => true;
    public override bool SlowDigest => true;
    public override int Cost => 40000;
    public override string BonusHitsRollExpression => "10";
    public override string BonusDamageRollExpression => "15";
    public override ColorEnum Color => ColorEnum.BrightWhite;
}
