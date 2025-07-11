namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BroadSwordBlackIceFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    public override bool BrandCold => true;
    public override string FriendlyName => "'Black Ice'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    /// <summary>
    /// Returns a value of 3 to add to the radius of light for a broad sword which provides no light.
    /// </summary>
    public override int Radius => 3;

    public override string? BonusStealthRollExpression => "3";
    public override bool ResCold => true;
    public override bool ShowMods => true;
    public override bool SlayEvil => true;
    public override bool SlayOrc => true;
    public override bool SlowDigest => true;
    public override bool Stealth => true;
}