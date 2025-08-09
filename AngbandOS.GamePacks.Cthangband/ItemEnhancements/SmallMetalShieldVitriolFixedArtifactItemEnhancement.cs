namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SmallMetalShieldVitriolFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 20;
    public override bool FreeAct => true;
    public override string FriendlyName => "'Vitriol'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ImAcid => true;
    public override string? BonusConstitutionRollExpression => "4";
    public override string? BonusStrengthRollExpression => "4";
    public override bool ResChaos => true;
    public override bool ResSound => true;
    public override int Cost => 60000;
    public override int DamageDice => 1;
}
