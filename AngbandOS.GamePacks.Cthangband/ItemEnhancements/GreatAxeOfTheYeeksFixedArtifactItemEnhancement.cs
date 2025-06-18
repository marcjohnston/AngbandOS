namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GreatAxeOfTheYeeksFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool Con => true;
    public override int TreasureRating => 20;
    public override bool FreeAct => true;
    public override string FriendlyName => "of the Yeeks";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool KillDragon => true;
    public override string? BonusConstitutionRollExpression => "3";
    public override bool ResAcid => true;
    public override bool ResChaos => true;
    public override bool ResDark => true;
    public override bool ResFire => true;
    public override bool ResLight => true;
    public override bool ShowMods => true;
    public override bool SlayDemon => true;
    public override bool SlayOrc => true;
    public override bool SlayTroll => true;
}