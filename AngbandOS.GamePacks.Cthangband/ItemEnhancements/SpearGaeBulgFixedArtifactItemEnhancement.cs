namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SpearGaeBulgFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    public override bool BrandCold => true;
    public override string FriendlyName => "'Gae Bulg'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Infra => true;
    public override string? BonusInfravisionRollExpression => "3";
    public override string? BonusSpeedRollExpression => "3";
    public override string? BonusStealthRollExpression => "3";
    public override bool ResCold => true;
    public override bool ResDark => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayUndead => true;
    public override bool Speed => true;
    public override bool Stealth => true;
    public override int Cost => 30000;
}
