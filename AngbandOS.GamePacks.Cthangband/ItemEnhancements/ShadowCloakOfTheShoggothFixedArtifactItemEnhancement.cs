namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ShadowCloakOfTheShoggothFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? TreasureRating => 10;
    public override bool? FreeAct => true;
    public override string FriendlyName => "of the Shoggoth";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ImAcid => true;
    public override string? Stealth => "4";
    public override bool? SeeInvis => true;
    public override int? Value => 35000;
    public override string Attacks => "12";
    public override ColorEnum? Color => ColorEnum.Black;
}
