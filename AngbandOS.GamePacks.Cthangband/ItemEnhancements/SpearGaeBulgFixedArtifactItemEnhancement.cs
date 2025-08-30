namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SpearGaeBulgFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? TreasureRating => 10;
    public override bool? BrandCold => true;
    public override string FriendlyName => "'Gae Bulg'";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override string? Infravision => "3";
    public override string? Speed => "3";
    public override string? Stealth => "3";
    public override bool? ResCold => true;
    public override bool? ResDark => true;
    public override bool? SeeInvis => true;
    public override bool? ShowMods => true;
    public override bool? SlayUndead => true;
    public override int? Value => 30000;
    public override string Hits => "11";
    public override string Damage => "13";
    public override ColorEnum? Color => ColorEnum.Grey;
}
