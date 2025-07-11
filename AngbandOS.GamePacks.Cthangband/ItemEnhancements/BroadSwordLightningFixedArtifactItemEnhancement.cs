namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BroadSwordLightningFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool BrandElec => true;
    public override int TreasureRating => 20;
    public override string FriendlyName => "'Lightning'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool KillDragon => true;
    /// <summary>
    /// Returns a value of 3 to add to the radius of light for a broad sword which provides no light.
    /// </summary>
    public override int Radius => 3;

    public override string? BonusSearchRollExpression => "4";
    public override bool ResElec => true;
    public override bool ResFear => true;
    public override bool ResFire => true;
    public override bool ResPois => true;
    public override bool Search => true;
    public override bool ShowMods => true;
    public override bool SlayOrc => true;
    public override bool SlowDigest => true;
}