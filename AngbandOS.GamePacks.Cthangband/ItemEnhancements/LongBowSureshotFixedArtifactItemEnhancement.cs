namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LongBowSureshotFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    public override bool Dex => true;
    public override string FriendlyName => "'Sureshot'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override string? BonusDexterityRollExpression => "3";
    public override string? BonusStealthRollExpression => "3";
    public override bool ResDisen => true;
    public override bool ShowMods => true;
    public override bool Stealth => true;
    public override bool XtraShots => true;
    public override int Cost => 35000;
}
