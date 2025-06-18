namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DaggerOfAssassinFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool BrandPois => true;
    public override int TreasureRating => 20;
    public override bool Dex => true;
    public override bool FreeAct => true;
    public override string FriendlyName => "of Assassin";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override string? BonusDexterityRollExpression => "4";
    public override string? BonusSearchRollExpression => "4";
    public override string? BonusStealthRollExpression => "4";
    public override bool ResDark => true;
    public override bool Search => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayEvil => true;
    public override bool SlayOrc => true;
    public override bool SlayTroll => true;
    public override bool Stealth => true;
    public override bool SustDex => true;
}