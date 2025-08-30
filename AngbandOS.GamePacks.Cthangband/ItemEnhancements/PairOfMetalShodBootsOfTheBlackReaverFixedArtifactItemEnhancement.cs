namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PairOfMetalShodBootsOfTheBlackReaverFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? TreasureRating => 10;
    public override bool? Aggravate => true;
    public override string FriendlyName => "of the Black Reaver";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override string? Constitution => "10";
    public override string? Speed => "10";
    public override string? Strength => "10";
    public override int? Value => 15000;
    public override string Attacks => "20";
    public override ColorEnum? Color => ColorEnum.Grey;
}
