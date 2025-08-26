namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PikeOfTepesFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    public override bool BrandCold => true;
    public override bool BrandFire => true;
    public override string FriendlyName => "of Tepes";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    /// <summary>
    /// Returns a value of 3 to add to the radius of light for a pike which provides no light.
    /// </summary>
    public override int Radius => 3;

    public override string? BonusIntelligenceRollExpression => "2";
    public override bool ResCold => true;
    public override bool ResFire => true;
    public override bool ShowMods => true;
    public override bool SlayDemon => true;
    public override bool SlayGiant => true;
    public override bool SlayTroll => true;
    public override bool SlowDigest => true;
    public override bool SustInt => true;
    public override int Value => 32000;
    public override string BonusAttacksRollExpression => "10";
    public override string BonusHitsRollExpression => "10";
    public override string BonusDamageRollExpression => "12";
    public override ColorEnum Color => ColorEnum.Grey;
}
