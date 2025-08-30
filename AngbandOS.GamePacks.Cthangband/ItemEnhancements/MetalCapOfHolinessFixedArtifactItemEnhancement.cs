namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MetalCapOfHolinessFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? TreasureRating => 10;
    public override string FriendlyName => "of Holiness";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override string? Charisma => "3";
    public override string? Wisdom => "3";
    public override int? Value => 22000;
    public override string Attacks => "12";
    public override ColorEnum? Color => ColorEnum.Grey;
}
