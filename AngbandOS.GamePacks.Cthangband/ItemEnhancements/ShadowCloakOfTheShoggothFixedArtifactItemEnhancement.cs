namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ShadowCloakOfTheShoggothFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    public override bool FreeAct => true;
    public override string FriendlyName => "of the Shoggoth";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ImAcid => true;
    public override string? BonusStealthRollExpression => "4";
    public override bool SeeInvis => true;
    public override bool Stealth => true;
}