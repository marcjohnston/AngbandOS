namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SetOfLeatherGlovesCalfskinFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? TreasureRating => 10;
    public override bool? FreeAct => true;
    public override string FriendlyName => "'Calfskin'";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override string? Constitution => "2";
    public override string? Strength => "2";
    public override bool? ShowMods => true;
    public override int? Value => 36000;
    public override string Attacks => "15";
    public override string Hits => "8";
    public override string Damage => "8";
    public override ColorEnum? Color => ColorEnum.BrightBrown;
}
