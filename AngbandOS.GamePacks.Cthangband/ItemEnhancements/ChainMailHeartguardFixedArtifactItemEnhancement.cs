namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ChainMailHeartguardFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? TreasureRating => 10;
    public override string FriendlyName => "'Heartguard'";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override string? Charisma => "2";
    public override string? Strength => "2";
    public override bool? ResAcid => true;
    public override bool? ResCold => true;
    public override bool? ResElec => true;
    public override bool? ResFire => true;
    public override bool? ResNexus => true;
    public override bool? ResShards => true;
    public override int? Value => 32000;
    public override string Attacks => "15";
    public override string Hits => "-2";
    public override ColorEnum? Color => ColorEnum.Grey;
}
