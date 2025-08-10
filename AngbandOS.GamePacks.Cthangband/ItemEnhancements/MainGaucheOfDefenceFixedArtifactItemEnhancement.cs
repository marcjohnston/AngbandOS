namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MainGaucheOfDefenceFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    public override bool FreeAct => true;
    public override string FriendlyName => "of Defence";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override string? BonusDexterityRollExpression => "3";
    public override string? BonusIntelligenceRollExpression => "3";
    public override string? BonusSpeedRollExpression => "3";
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayGiant => true;
    public override bool SlayTroll => true;
    public override int Cost => 22500;
    public override int DamageDice => 1;
    public override string BonusHitRollExpression => "12";
    public override string BonusDamageRollExpression => "15";
}
