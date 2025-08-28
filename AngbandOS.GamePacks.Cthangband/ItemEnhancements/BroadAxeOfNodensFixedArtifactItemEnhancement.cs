namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BroadAxeOfNodensFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? TreasureRating => 10;
    public override string FriendlyName => "of Nodens";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override string? BonusConstitutionRollExpression => "3";
    public override bool? SeeInvis => true;
    public override bool? ShowMods => true;
    public override bool? SlayEvil => true;
    public override bool? SlayGiant => true;
    public override bool? SlayOrc => true;
    public override bool? SlayTroll => true;
    public override int? Value => 50000;
    public override string BonusHitsRollExpression => "13";
    public override string BonusDamageRollExpression => "19";
    public override ColorEnum? Color => ColorEnum.Grey;
}
