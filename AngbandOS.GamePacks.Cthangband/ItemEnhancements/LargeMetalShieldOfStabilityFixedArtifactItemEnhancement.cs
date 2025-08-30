namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LargeMetalShieldOfStabilityFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? TreasureRating => 20;
    public override string FriendlyName => "of Stability";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResAcid => true;
    public override bool? ResCold => true;
    public override bool? ResElec => true;
    public override bool? ResFire => true;
    public override bool? SustCha => true;
    public override bool? SustCon => true;
    public override bool? SustDex => true;
    public override bool? SustInt => true;
    public override bool? SustStr => true;
    public override bool? SustWis => true;
    public override int? Value => 160000;
    public override string Attacks => "20";
    public override ColorEnum? Color => ColorEnum.Grey;
}
