namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GreatAxeOfTheYeeksFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? TreasureRating => 20;
    public override bool? FreeAct => true;
    public override string FriendlyName => "of the Yeeks";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override int? SlayDragon => 5;
    public override string? Constitution => "3";
    public override bool? ResAcid => true;
    public override bool? ResChaos => true;
    public override bool? ResDark => true;
    public override bool? ResFire => true;
    public override bool? ResLight => true;
    public override bool? ShowMods => true;
    public override bool? SlayDemon => true;
    public override bool? SlayOrc => true;
    public override bool? SlayTroll => true;
    public override int? Value => 150000;
    public override string Attacks => "15";
    public override string Hits => "10";
    public override string Damage => "20";
    public override ColorEnum? Color => ColorEnum.Grey;
}
