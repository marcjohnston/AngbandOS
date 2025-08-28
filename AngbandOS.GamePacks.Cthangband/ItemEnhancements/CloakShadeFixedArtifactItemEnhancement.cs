namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CloakShadeFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? TreasureRating => 10;
    public override bool? FreeAct => true;
    public override string FriendlyName => "'Shade'";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResAcid => true;
    public override bool? SeeInvis => true;
    public override int? Value => 8000;
    public override string BonusAttacksRollExpression => "10";
    public override ColorEnum? Color => ColorEnum.Green;
}
