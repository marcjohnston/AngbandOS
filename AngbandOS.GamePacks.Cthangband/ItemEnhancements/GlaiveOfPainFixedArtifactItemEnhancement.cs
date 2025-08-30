namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GlaiveOfPainFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? TreasureRating => 10;
    public override string FriendlyName => "of Pain";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ShowMods => true;
    public override int? Value => 50000;
    public override int? DamageDice => 7;
    public override string Damage => "30";
    public override ColorEnum? Color => ColorEnum.Grey;
}
