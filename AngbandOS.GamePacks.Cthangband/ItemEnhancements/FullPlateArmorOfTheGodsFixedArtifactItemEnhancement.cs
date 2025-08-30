namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class FullPlateArmorOfTheGodsFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? TreasureRating => 10;
    public override string FriendlyName => "of the Gods";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override string? Constitution => "1";
    public override bool? ResAcid => true;
    public override bool? ResCold => true;
    public override bool? ResConf => true;
    public override bool? ResElec => true;
    public override bool? ResFire => true;
    public override bool? ResNexus => true;
    public override bool? ResSound => true;
    public override int? Weight => -80;
    public override int? Value => 50000;
    public override string Attacks => "25";
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
